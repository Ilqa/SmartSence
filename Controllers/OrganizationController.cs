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
            _logger = logger;
        }


        [HttpGet("Organizations")]
        public async Task<IActionResult> GetAllOrganizations() => Ok(await _orgService.GetAllOrganizations());

        [HttpPost("Organization")]
        public async Task<IActionResult> AddOrganization(OrganizationDto org) => Ok(await _orgService.AddOrganization(org));

        [HttpPost("Sector")]
        public async Task<IActionResult> AddSector(SectorDto sector) => Ok(await _orgService.AddSector(sector));

        [HttpPut("Sector")]
        public async Task<IActionResult> UpdateSector(SectorDto sector) => Ok(await _orgService.UpdateSector(sector));

        [HttpPost("Block")]
        public async Task<IActionResult> AddBlock(BlockDto block) => Ok(await _orgService.AddBlock(block));

        [HttpPut("Block")]
        public async Task<IActionResult> UpdateBlock(BlockDto block) => Ok(await _orgService.UpdateBlock(block));

        [HttpPost("House")]
        public async Task<IActionResult> AddHouse(HouseDto house) => Ok(await _orgService.AddHouse(house));

        [HttpPut("House")]
        public async Task<IActionResult> UpdateHouse(HouseDto house) => Ok(await _orgService.UpdateHouse(house));
    }
}