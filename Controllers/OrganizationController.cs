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
        public async Task<IActionResult> GetAll(int? pageNumber, int? pageSize, string? sortField, string? sortOrder, string? searchText)
        {
            //var orgs = await _orgService.GetAllAsync(pageNumber ?? 1, pageSize ?? 10, sortField ?? "Name", sortOrder ?? "ASC", searchText ?? "");
            //orgs.Data.Add(new OrganizationDto() { Id = 1, Name = "Org1", Address = "bloack A AIT Lahore", Coordinates = "xy" });
            //orgs.TotalCount = 1;
            //return Ok(orgs);    
            return Ok(await _orgService.GetAllAsync(pageNumber ?? 1, pageSize ?? 10, sortField ?? "Name", sortOrder ?? "ASC", searchText ?? ""));
        }

        [HttpGet("AllOrganizations")]
        public async Task<IActionResult> GetAllOrganizations() => Ok(await _orgService.GetAllOrganizationsLite());

        [HttpGet("OrganizationById/{id}")]
        public async Task<IActionResult> GetOrganizationById(long id) => Ok(await _orgService.GetOrganizationById(id));

        [HttpPost("Organization")]
        public async Task<IActionResult> AddOrganization(OrganizationDto org) => Ok(await _orgService.AddOrganization(org));

        [HttpPut("Organization")]
        public async Task<IActionResult> UpdateOrganization(OrganizationDto org) => Ok(await _orgService.UpdateOrganization(org));

        [HttpPut("DeleteOrganization")]
        public async Task<IActionResult> DeleteOrganization(long id) => Ok(await _orgService.DeleteOrganization(id));




        [HttpGet("AllSectorsLite/{orgId}")]
        public async Task<IActionResult> GetAllSectorsLite(long orgId) => Ok(await _orgService.GetAllSectorsLite(orgId));

        [HttpGet("Sectors/{orgId}")]
        public async Task<IActionResult> GetAllSectors(long orgId) => Ok(await _orgService.GetAllSectors(orgId));

        [HttpGet("AllSectors")]
        public async Task<IActionResult> GetAllSectors() => Ok(await _orgService.GetAllSectors());

        [HttpPost("Sector")]
        public async Task<IActionResult> AddSector(SectorDto sector) => Ok(await _orgService.AddSector(sector));

        [HttpPut("Sector")]
        public async Task<IActionResult> UpdateSector(SectorDto sector) => Ok(await _orgService.UpdateSector(sector));

        [HttpGet("SectorById/{id}")]
        public async Task<IActionResult> GetSectorById(long id) => Ok(await _orgService.GetSectorById(id));

        [HttpPut("DeleteSector")]
        public async Task<IActionResult> DeleteSector(long id) => Ok(await _orgService.DeleteSector(id));




        [HttpGet("AllBlocksLite/{sectorId}")]
        public async Task<IActionResult> GetAllBlocksLite(long sectorId) => Ok(await _orgService.GetAllBlocksLite(sectorId));

        [HttpGet("Blocks/{sectorId}")]
        public async Task<IActionResult> GetAllBlocks(long sectorId) => Ok(await _orgService.GetAllBlocks(sectorId));

        [HttpGet("AllBlocks")]
        public async Task<IActionResult> GetAllBlocks() => Ok(await _orgService.GetAllBlocks());

        [HttpPost("Block")]
        public async Task<IActionResult> AddBlock(BlockDto block) => Ok(await _orgService.AddBlock(block));

        [HttpPut("Block")]
        public async Task<IActionResult> UpdateBlock(BlockDto block) => Ok(await _orgService.UpdateBlock(block));

        [HttpGet("BlockById/{id}")]
        public async Task<IActionResult> GetBlockById(long id) => Ok(await _orgService.GetBlockById(id));

        [HttpPut("DeleteBlock")]
        public async Task<IActionResult> DeleteBlock(long id) => Ok(await _orgService.DeleteBlock(id));






        [HttpGet("Building/{blockId}")]
        public async Task<IActionResult> GetAllHouses(long blockId) => Ok(await _orgService.GetAllBuildings(blockId));

        [HttpGet("AllBuildings")]
        public async Task<IActionResult> GetAllHouses() => Ok(await _orgService.GetAllBuildings());

        [HttpPost("Building")]
        public async Task<IActionResult> AddHouse(BuildingDto house) => Ok(await _orgService.AddBuilding(house));

        [HttpPut("Building")]
        public async Task<IActionResult> UpdateHouse(BuildingDto house) => Ok(await _orgService.UpdateBuilding(house));

        [HttpGet("AllBuildingsLite/{blockId}")]
        public async Task<IActionResult> GetAllBuildingsLite(long blockId) => Ok(await _orgService.GetAllBuildingsLite(blockId));

        [HttpGet("BuildingById/{id}")]
        public async Task<IActionResult> GetBuildingById(long id) => Ok(await _orgService.GetBuildingById(id));

        [HttpPut("DeleteBuilding")]
        public async Task<IActionResult> DeleteBuilding(long id) => Ok(await _orgService.DeleteBuilding(id));



        [HttpGet("Floor/{buildingId}")]
        public async Task<IActionResult> GetAllBuildingFloors(long buildingId) => Ok(await _orgService.GetAllBuildingFloors(buildingId));

        [HttpGet("AllFloors")]
        public async Task<IActionResult> GetAllBuildingFloors() => Ok(await _orgService.GetAllBuildingFloors());

        [HttpPost("Floor")]
        public async Task<IActionResult> AddBuildingFloor(BuildingFloorDto house) => Ok(await _orgService.AddBuildingFloor(house));

        [HttpPut("Floor")]
        public async Task<IActionResult> UpdateBuildingFloor(BuildingFloorDto house) => Ok(await _orgService.UpdateBuildingFloor(house));

        [HttpGet("AllFloorsLite/{buildingId}")]
        public async Task<IActionResult> GetAllFloorsLite(long buildingId) => Ok(await _orgService.GetAllFloorsLite(buildingId));

        [HttpGet("FloorById/{id}")]
        public async Task<IActionResult> GetFloorById(long id) => Ok(await _orgService.GetFloorById(id));

        [HttpPut("DeleteFloor")]
        public async Task<IActionResult> DeleteFloor(long id) => Ok(await _orgService.DeleteBuildingFloor(id));







        [HttpGet("Rooms/{floorId}")]
        public async Task<IActionResult> GetAllRooms(long floorId) => Ok(await _orgService.GetAllRooms(floorId));

        [HttpGet("AllRooms")]
        public async Task<IActionResult> GetAllRooms() => Ok(await _orgService.GetAllRooms());

        [HttpPost("Room")]
        public async Task<IActionResult> AddRoom(RoomDto room) => Ok(await _orgService.AddRoom(room));

        [HttpPut("Room")]
        public async Task<IActionResult> UpdateRoom(RoomDto room) => Ok(await _orgService.UpdateRoom(room));

        [HttpGet("AllRoomsLite/{Id}")]
        public async Task<IActionResult> GetAllRoomsLite(long Id) => Ok(await _orgService.GetAllRoomsLite(Id));

        [HttpGet("RoomById/{id}")]
        public async Task<IActionResult> GetRoomById(long id) => Ok(await _orgService.GetRoomById(id));

        [HttpPut("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(long id) => Ok(await _orgService.DeleteRoom(id));
    }
}