using Microsoft.AspNetCore.Mvc;
using SmartSence.DTO;
using SmartSence.Services;

namespace SmartSence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _orgService;

       

        private readonly ILogger<OrganizationController> _logger;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService orgService)
        {
            _orgService = orgService;
        }


        [HttpGet("Organizations")]
        public async Task<IActionResult> GetAllOrganizations() => Ok(await _orgService.GetAllOrganizations());

        [HttpPost("Organization")]
        public async Task<IActionResult> AddOrganization(OrganizationDto org) => Ok(await _orgService.AddOrganization(org));
    }
}