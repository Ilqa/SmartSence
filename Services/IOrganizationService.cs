
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IOrganizationService
    {    
        
        Task<IResult> AddOrganization(OrganizationDto company);
        Task<IResult> UpdateOrganization(OrganizationDto company);
        Task<IResult> DeleteOrganization(long id);
        Task<Result<List<OrganizationDto>>> GetAllOrganizations();
        Task<IResult> AddSector(SectorDto sector);
        Task<IResult> UpdateSector(SectorDto sector);
        Task<IResult> DeleteSector(long id);
        Task<Result<List<SectorDto>>> GetAllSectors(long orgId);
        Task<IResult> AddBlock(BlockDto block);
        Task<IResult> UpdateBlock(BlockDto block);
        Task<IResult> DeleteBlock(long id);
        Task<Result<List<BlockDto>>> GetAllBlocks(long sectorId);
        Task<IResult> AddHouse(HouseDto house);
        Task<IResult> UpdateHouse(HouseDto house);
        Task<IResult> DeleteHouse (long id);
        Task<Result<List<HouseDto>>> GetAllHouses(long blockId);

    }
}
