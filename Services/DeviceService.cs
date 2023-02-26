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
        
        private readonly IOrganizationRepository _organizationRepository;
        private readonly RoleManager<UserRole> _roleManager;
       
        private readonly IUnitOfWork _unitOfWork;


        public DeviceService(IOrganizationRepository companyRepository, RoleManager<UserRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _organizationRepository = companyRepository;
            _mapper = mapper;
            _roleManager = roleManager;
           
            _unitOfWork = unitOfWork;
        }

        public Task<Wrappers.IResult> AddDevice(DeviceDto device)
        {
            throw new NotImplementedException();
        }

    }
}
