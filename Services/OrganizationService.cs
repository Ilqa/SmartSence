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
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        
        private readonly IOrganizationRepository _organizationRepository;
        private readonly RoleManager<UserRole> _roleManager;
       
        private readonly IUnitOfWork _unitOfWork;


        public OrganizationService(IOrganizationRepository companyRepository, RoleManager<UserRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _organizationRepository = companyRepository;
            _mapper = mapper;
            _roleManager = roleManager;
           
            _unitOfWork = unitOfWork;
        }


        public async Task<Wrappers.Result<List<OrganizationDto>>> GetAllOrganizations()
        {
            var orgs = await _organizationRepository.GetAllOrganizations();
            return await Result<List<OrganizationDto>>.SuccessAsync(_mapper.Map<List<OrganizationDto>>(orgs));
        }

        public async Task<Wrappers.IResult> AddOrganization(OrganizationDto org)
        {
            await _organizationRepository.AddOrganization(_mapper.Map<Organization>(org));
        
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Organization Added Successfully");
    }
    }
}
