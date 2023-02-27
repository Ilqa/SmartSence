using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        


        public DeviceService( IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<Wrappers.IResult> AddDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }

        public Task<Wrappers.IResult> DeleteDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }

        public Task<Wrappers.IResult> SaveDeviceTelemetry(int deviveId, JsonContent content)
        {
            throw new NotImplementedException();
        }

        public Task<Wrappers.IResult> UpdateDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }
    }
}
