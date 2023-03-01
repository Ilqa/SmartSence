using Microsoft.AspNetCore.Mvc;
using SmartSence.DTO;
using SmartSence.Services;

namespace SmartSence.Controllers
{
    [ApiController]
    [Route("api/")]
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

        [HttpPut("Organization")]
        public async Task<IActionResult> UpdateOrganization(OrganizationDto org) => Ok(await _orgService.UpdateOrganization(org));

        [HttpGet("Sectors/{id}")]
        public async Task<IActionResult> GetAllSectors(long id) => Ok(await _orgService.GetAllSectors(id));

        [HttpPost("Sector")]
        public async Task<IActionResult> AddSector(SectorDto sector) => Ok(await _orgService.AddSector(sector));

        [HttpPut("Sector")]
        public async Task<IActionResult> UpdateSector(SectorDto sector) => Ok(await _orgService.UpdateSector(sector));

        [HttpGet("Blocks/{id}")]
        public async Task<IActionResult> GetAllBlocks(long id) => Ok(await _orgService.GetAllBlocks(id));

        [HttpPost("Block")]
        public async Task<IActionResult> AddBlock(BlockDto block) => Ok(await _orgService.AddBlock(block));

        [HttpPut("Block")]
        public async Task<IActionResult> UpdateBlock(BlockDto block) => Ok(await _orgService.UpdateBlock(block));

        [HttpGet("Building/{id}")]
        public async Task<IActionResult> GetAllHouses(long id) => Ok(await _orgService.GetAllBuildings(id));

        [HttpPost("Building")]
        public async Task<IActionResult> AddHouse(BuildingDto house) => Ok(await _orgService.AddBuilding(house));

        [HttpPut("Building")]
        public async Task<IActionResult> UpdateHouse(BuildingDto house) => Ok(await _orgService.UpdateBuilding(house));

        [HttpGet("BuildingFloor/{id}")]
        public async Task<IActionResult> GetAllBuildingFloors(long id) => Ok(await _orgService.GetAllBuildingFloors(id));;

        [HttpPost("BuildingFloor")]
        public async Task<IActionResult> AddBuildingFloor(BuildingFloorDto house) => Ok(await _orgService.AddBuildingFloor(house));

        [HttpPut("BuildingFloor")]
        public async Task<IActionResult> UpdateBuildingFloor(BuildingFloorDto house) => Ok(await _orgService.UpdateBuildingFloor(house));
    }
}