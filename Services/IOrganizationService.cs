
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IOrganizationService
    {
        #region Organization
        Task<IResult> AddOrganization(OrganizationDto company);

        Task<PaginatedResult<OrganizationDto>> GetAllAsync(int pageNumber, int pageSize, string sortField, string sortOrder, string searchText);
        Task<Result<List<LiteEntityDto>>> GetAllOrganizationsLite();
        Task<IResult> UpdateOrganization(OrganizationDto company);
        Task<IResult> DeleteOrganization(long id);
        Task<Result<OrganizationDto>> GetOrganizationById(long id);
        //Task<Result<List<OrganizationDto>>> GetAllOrganizations();
#endregion

        #region Sector
        Task<IResult> AddSector(SectorDto sector);
        Task<IResult> UpdateSector(SectorDto sector);
        Task<IResult> DeleteSector(long id);
        Task<Result<List<SectorDto>>> GetAllSectors(long orgId);
        Task<Result<List<SectorDto>>> GetAllSectors();
        Task<Result<List<LiteEntityDto>>> GetAllSectorsLite(long orgId);
        Task<Result<SectorDto>> GetSectorById(long id);
#endregion

        #region Block
        Task<IResult> AddBlock(BlockDto block);
        Task<IResult> UpdateBlock(BlockDto block);
        Task<IResult> DeleteBlock(long id);
        Task<Result<List<LiteEntityDto>>> GetAllBlocksLite(long sectorId);
        Task<Result<List<BlockDto>>> GetAllBlocks(long sectorId);
        Task<Result<List<BlockDto>>> GetAllBlocks();
        Task<Result<BlockDto>> GetBlockById(long id);
#endregion


        #region Building
        Task<IResult> AddBuilding(BuildingDto building);
        Task<IResult> UpdateBuilding(BuildingDto building);
        Task<IResult> DeleteBuilding (long id);
        Task<Result<List<BuildingDto>>> GetAllBuildings(long blockId);
        Task<Result<List<BuildingDto>>> GetAllBuildings();
        Task<Result<List<LiteEntityDto>>> GetAllBuildingsLite(long blockId);
        Task<Result<BuildingDto>> GetBuildingById(long id);
#endregion


        #region Floor
        Task<IResult> AddBuildingFloor(BuildingFloorDto floor);
        Task<IResult> UpdateBuildingFloor(BuildingFloorDto floor);
        Task<IResult> DeleteBuildingFloor(long id);
        Task<Result<List<BuildingFloorDto>>> GetAllBuildingFloors(long buildingId);
        Task<Result<List<BuildingFloorDto>>> GetAllBuildingFloors();
        Task<Result<List<LiteEntityDto>>> GetAllFloorsLite(long buildingId);
        Task<Result<BuildingFloorDto>> GetFloorById(long id);


        #endregion

        #region room
        Task<IResult> AddRoom(RoomDto room);
        Task<IResult> UpdateRoom(RoomDto room);
        Task<IResult> DeleteRoom(long id);
        Task<Result<List<RoomDto>>> GetAllRooms(long floorId);
        Task<Result<List<RoomDto>>> GetAllRooms();
        Task<Result<RoomDto>> GetRoomById(long id);
        Task<Result<List<LiteEntityDto>>> GetAllRoomsLite(long orgId);
        #endregion


    }
}
