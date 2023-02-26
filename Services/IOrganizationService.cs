
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IOrganizationService
    {
        
        Task<Result<List<OrganizationDto>>> GetAllOrganizations();
        Task<IResult> AddOrganization(OrganizationDto company);
       
    }
}
