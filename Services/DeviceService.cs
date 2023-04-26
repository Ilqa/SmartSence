using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database;
using SmartSence.Database.Entities;
using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.Wrappers;

namespace SmartSence.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryAsync<Device> _repositoryAsync;
        private readonly IRepositoryAsync<DeviceType> _deviceTypeRepo;
        private readonly IRepositoryAsync<DeviceTelemetry> _telemetryRepo;
        private readonly IRepositoryAsync<DeviceTelemetryJson> _telemetryJsonRepo;
        private readonly SmartSenceContext _context;




        public DeviceService(IRepositoryAsync<DeviceType> deviceTypeRepo, SmartSenceContext dbContext, IMapper mapper, IUnitOfWork unitOfWork, IRepositoryAsync<Device> repositoryAsync, IRepositoryAsync<DeviceTelemetry> telemetryRepo, IRepositoryAsync<DeviceTelemetryJson> telemetryJsonRepo)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repositoryAsync = repositoryAsync;
            _telemetryRepo= telemetryRepo;
            _telemetryJsonRepo= telemetryJsonRepo;
            _context = dbContext;
            _deviceTypeRepo = deviceTypeRepo;
        }

        public async Task<Wrappers.IResult> AddDevice(DeviceDto device)
        {
            await _repositoryAsync.AddAsync(_mapper.Map<Device>(device));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Device Added Successfully");
        }

        public Task<Wrappers.IResult> DeleteDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<DeviceDto>>> GetDevicesByFloor(long id)
        {
            var devices = await _repositoryAsync.Entities.Where(s => s.RoomId == id).ToListAsync();
            return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        }

        public async Task<Result<List<DeviceDto>>> GetDevicesByHouse(long id)
        {
            var devices = await _repositoryAsync.Entities.Where(s => s.Room.BuildingFloor.BuildingId == id).ToListAsync();
            return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        }

        public async Task<Result<List<DeviceDto>>> GetDevicesByOrganization(long id)
        {
            var devices = await _repositoryAsync.Entities.Where(s => s.Orgid == id).ToListAsync();
            return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        }

        //public Task<Result<List<DeviceDto>>> GetDevicesBySector(long id)
        //{
        //    var devices = await _repositoryAsync.Entities.Where(s => s.Orgid == id).ToListAsync();
        //    return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        //}

        public async Task<Wrappers.IResult> SaveDeviceTelemetry(DeviceTelemetryDto telemetry)
        {
            int? deviceId = _repositoryAsync.Entities.FirstOrDefault(d => d.DeviceEUI == telemetry.DeviceEui)?.Id;
            if(deviceId == null)
                return await Result.FailAsync("Device not recognized");

            var deviceTelemetry = _mapper.Map<DeviceTelemetry>(telemetry);
            deviceTelemetry.Deviceid = deviceId;
            await _telemetryRepo.AddAsync(deviceTelemetry);
            await _telemetryJsonRepo.AddAsync(new DeviceTelemetryJson() { DeviceId = deviceId.Value, MsqJson = deviceTelemetry.Data });
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Device Telemetry Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateDevice(DeviceDto device)
        {
            var deviceDb = await _repositoryAsync.Entities.FirstOrDefaultAsync(s => s.Id == device.Id);
            if (deviceDb == null)
                return Result<long>.Fail($"Device Not Found.");

            deviceDb = _mapper.Map(device, deviceDb);
            await _repositoryAsync.UpdateAsync(deviceDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(deviceDb.Id, "Device updated successfully");
        }

        public async Task<Result<DashboardSummary>> GetDeviceSummary(DashboardFilter filter)
        {
            
            var summary = new DashboardSummary
            {
                EntityType = "Device",
                OnlineEntites = filter.OrgId == 1? 2:0,
                OfflineEntities = 0
            };

            return await Result<DashboardSummary>.SuccessAsync(summary);
        }

        public async Task<Result<string>> RegidterDeviceType(DeviceTypeDto deviceType)
        {
            try
            {
                await _deviceTypeRepo.AddAsync(_mapper.Map<DeviceType>(deviceType));

                // using var context = _context;
                var tableName = deviceType.TelemetryDBName; //"DeviceTelemetry_" + deviceType.Name.Replace(" ", "");
                var columns = new List<string> { "Id", "Seqno", "AppEui", "Time", "Port", "DeviceId", "SerialNumber" };
                var dataTypes = new List<string> { "serial primary key", "bigint", "text", "timestamp with time zone", "integer", "integer", "bigint" };
                deviceType.DeviceTypeColumns.ForEach(col => { columns.Add(col.Name); dataTypes.Add(col.DataType); });

                _context.Database.ExecuteSqlRaw("SELECT CreateTelemetryTable(@p0, @p1, @p2)", tableName, columns.ToArray(), dataTypes.ToArray());
            }
            catch(Exception ex) { return await Result<string>.FailAsync(ex.ToString()); }

            await _unitOfWork.Commit();
            return await Result<string>.SuccessAsync("Device Registered");           

        }
    }
}
