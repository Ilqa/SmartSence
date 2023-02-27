using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database.Entities;
using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.Wrappers;
using System.Security.Cryptography;

namespace SmartSence.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryAsync<DeviceInfo> _repositoryAsync;
        


        public DeviceService( IMapper mapper, IUnitOfWork unitOfWork, IRepositoryAsync<DeviceInfo> repositoryAsync)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Wrappers.IResult> AddDevice(DeviceDto device)
        {
            await _repositoryAsync.AddAsync(_mapper.Map<DeviceInfo>(device));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Device Added Successfully");
        }

        public Task<Wrappers.IResult> DeleteDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<DeviceDto>>> GetDevicesByHouse(long id)
        {
            var devices = await _repositoryAsync.Entities.Where(s => s.Houseid == id).ToListAsync();
            return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        }

        public async Task<Result<List<DeviceDto>>> GetDevicesByOrganization(long id)
        {
            var devices = await _repositoryAsync.Entities.Where(s => s.Orgid == id).ToListAsync();
            return await Result<List<DeviceDto>>.SuccessAsync(_mapper.Map<List<DeviceDto>>(devices));
        }

        public Task<Wrappers.IResult> SaveDeviceTelemetry(int deviveId, JsonContent content)
        {
            throw new NotImplementedException();
        }

        public async Task<Wrappers.IResult> UpdateDevice(DeviceDto device)
        {
            var deviceDb = await _repositoryAsync.Entities.FirstOrDefaultAsync(s => s.Id == device.Id);
            if (deviceDb == null)
                return Result<long>.Fail($"DEvice Not Found.");

            deviceDb = _mapper.Map(device, deviceDb);
            await _repositoryAsync.UpdateAsync(deviceDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(deviceDb.Id, "Device updated successfully");
        }
    }
}
