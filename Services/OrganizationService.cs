using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database.Entities;
using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.DTO.Identity;
using SmartSence.Extensions;
using SmartSence.Wrappers;
using System.Drawing;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;


namespace SmartSence.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Organization> _organizationRepository;
        private readonly IRepositoryAsync<Sector> _sectorRepository;
        private readonly IRepositoryAsync<Block> _blockRepository;
        private readonly IRepositoryAsync<Building> _buildingRepository;
        private readonly IRepositoryAsync<BuildingFloor> _buildingFloorRepository;
        private readonly IRepositoryAsync<Room> _roomRepository;

        private readonly IUnitOfWork _unitOfWork;


        public OrganizationService(IRepositoryAsync<Room> roomRepository, IRepositoryAsync<Organization> organizationRepository, IRepositoryAsync<BuildingFloor> buildingFloorRepository, IRepositoryAsync<Building> houseRepository, IRepositoryAsync<Sector> sectorRepository, IRepositoryAsync<Block> blockRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            //_roleManager = roleManager;
            _sectorRepository = sectorRepository;
            _blockRepository = blockRepository;
            _buildingRepository = houseRepository;
            _buildingFloorRepository = buildingFloorRepository;
            _unitOfWork = unitOfWork;
            _roomRepository= roomRepository;
        }

        //Task<List<LiteEntityDto>> IOrganizationService.GetAllOrganizations()
        #region Organization

        public async Task<Wrappers.Result<List<LiteEntityDto>>> GetAllOrganizationsLite()
        {
            var orgs = await _organizationRepository.GetAllAsync();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(orgs));
        }     

        public async Task<PaginatedResult<OrganizationDto>> GetAllAsync(int pageNumber, int pageSize, string sortField, string sortOrder, string searchText)
        {           
            var filteredOrgs = searchText.IsNullOrEmpty()
                ? _organizationRepository.Entities
                : _organizationRepository.Entities.Where(p => p.Name.Contains(searchText));

            var sortedOrgs = filteredOrgs.OrderBy($"{sortField} {sortOrder}");
            
            var orgs = sortedOrgs.Select(l => _mapper.Map<OrganizationDto>(l)).ToPaginatedListAsync(pageNumber, pageSize);

            //foreach (var mappedUser in userResponses.Result.Data)
            //{
            //    var user = sortedUsers.First(u => u.Id.Equals(mappedUser.Id));
            //    var roles = await _userManager.GetRolesAsync(user);
            //    mappedUser.Roles = roles.ToList();
            //}

            return await orgs;

        }

        public async Task<Wrappers.IResult> AddOrganization(OrganizationDto org)
        {
            await _organizationRepository.AddAsync(_mapper.Map<Organization>(org));       
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Organization Added Successfully");
    }

        public async Task<Wrappers.IResult> UpdateOrganization(OrganizationDto org)
        {
            var orgDb = await _organizationRepository.Entities.FirstOrDefaultAsync(s => s.Id == org.Id);
            if (orgDb == null)
                return Result<long>.Fail($"Organization Not Found.");

            orgDb = _mapper.Map(org, orgDb);
            await _organizationRepository.UpdateAsync(orgDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(orgDb.Id, "Organization updated successfully");
        }

        public async Task<Wrappers.IResult> DeleteOrganization(long id)
        {
            var OrgDB = await _organizationRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (OrgDB == null)
                return Result<long>.Fail($"Organization Not Found.");

            OrgDB.IsDeleted = true;
            await _organizationRepository.UpdateAsync(OrgDB);
            await _unitOfWork.Commit();
            return Result<long>.Success(id, "Organization deleted successfully");
        }

        public async Task<Wrappers.Result<List<LiteEntityDto>>> GetAllSectorsLite(long orgId)
        {
            var orgs = await _sectorRepository.GetAllAsync();
            orgs = orgs.Where(s => s.Orgid == orgId).ToList();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(orgs));
        }
        public async Task<Result<OrganizationDto>> GetOrganizationById(long id)
        {
            var org = await _organizationRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<OrganizationDto>.FailAsync("Organization not found");
            return await Result<OrganizationDto>.SuccessAsync(_mapper.Map<OrganizationDto>(org));
        }
        #endregion

        #region Sector
        public async Task<Wrappers.IResult> AddSector(SectorDto sector)
        {
            await _sectorRepository.AddAsync(_mapper.Map<Sector>(sector));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Sector Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateSector(SectorDto sector)
        {
            var sectorDb = await _sectorRepository.Entities.FirstOrDefaultAsync(s => s.Id == sector.Id);
            if (sectorDb == null)
                return Result<long>.Fail($"Sector Not Found.");

            sectorDb = _mapper.Map(sector, sectorDb);
            await _sectorRepository.UpdateAsync(sectorDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(sectorDb.Id, "Sector updated successfully");
        }



        public async Task<Wrappers.IResult> DeleteSector(long id)
        {
            var sector = await _sectorRepository.GetByIdAsync(id);
            if (sector == null)
                return Result<long>.Fail("No Sector Found");

           if( _blockRepository.Entities.Any(b => b.Sectorid == id))
                return Result<long>.Fail("Sector has one or more blocks linked to it");

            sector.IsDeleted = true;
            await _sectorRepository.UpdateAsync(sector);
            await _unitOfWork.Commit();
            return Result<long>.Success(sector.Id, "Sector deleted successfully");
        }

        public async Task<Result<List<SectorDto>>> GetAllSectors(long orgId)
        {
            var sectors = await _sectorRepository.Entities.Where(s => s.Orgid== orgId).ToListAsync();
            return await Result<List<SectorDto>>.SuccessAsync(_mapper.Map<List<SectorDto>>(sectors));
        }

        public async Task<Result<List<SectorDto>>> GetAllSectors()
        {
            var sectors = await _sectorRepository.Entities.ToListAsync();
            return await Result<List<SectorDto>>.SuccessAsync(_mapper.Map<List<SectorDto>>(sectors));
        }
        public async Task<Result<SectorDto>> GetSectorById(long id)
        {
            var org = await _sectorRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<SectorDto>.FailAsync("Sector not found");
            return await Result<SectorDto>.SuccessAsync(_mapper.Map<SectorDto>(org));
        }

        #endregion

        #region Block

        public async Task<Wrappers.IResult> AddBlock(BlockDto block)
        {
            await _blockRepository.AddAsync(_mapper.Map<Block>(block));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Block Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateBlock(BlockDto block)
        {
            var blockDb = await _blockRepository.Entities.FirstOrDefaultAsync(s => s.Id == block.Id);
            if (blockDb == null)
                return Result<long>.Fail($"Block Not Found.");

            blockDb = _mapper.Map(block, blockDb);
            await _blockRepository.UpdateAsync(blockDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(blockDb.Id, "Block updated successfully");
        }

        public async Task<Wrappers.IResult> DeleteBlock(long id)
        {
            var block = await _blockRepository.GetByIdAsync(id);
            if (block == null)
                return Result<long>.Fail("No block Found");

            if (_buildingRepository.Entities.Any(b => b.Blockid == id))
                return Result<long>.Fail("Block has one or more buildings linked to it");

            block.IsDeleted = true;
            await _blockRepository.UpdateAsync(block);
            await _unitOfWork.Commit();
            return Result<long>.Success(block.Id, "Block deleted successfully");
        }

        public async Task<Result<List<BlockDto>>> GetAllBlocks(long sectorId)
        {
            var blocks = await _blockRepository.Entities.Where(s => s.Sectorid == sectorId).ToListAsync();
            return await Result<List<BlockDto>>.SuccessAsync(_mapper.Map<List<BlockDto>>(blocks));
        }

        public async Task<Result<List<BlockDto>>> GetAllBlocks()
        {
            var blocks = await _blockRepository.Entities.ToListAsync();
            return await Result<List<BlockDto>>.SuccessAsync(_mapper.Map<List<BlockDto>>(blocks));
        }

        public async Task<Wrappers.Result<List<LiteEntityDto>>> GetAllBlocksLite(long sectorId)
        {
            var orgs = await _blockRepository.GetAllAsync();
            orgs = orgs.Where(s => s.Sectorid == sectorId).ToList();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(orgs));
        }
        public async Task<Result<BlockDto>> GetBlockById(long id)
        {
            var org = await _blockRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<BlockDto>.FailAsync("Block not found");
            return await Result<BlockDto>.SuccessAsync(_mapper.Map<BlockDto>(org));
        }

        #endregion

        #region Building
        public async Task<Wrappers.IResult> AddBuilding(BuildingDto building)
        {
            await _buildingRepository.AddAsync(_mapper.Map<Building>(building));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Building Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateBuilding(BuildingDto building)
        {
            var houseDb = await _buildingRepository.Entities.FirstOrDefaultAsync(s => s.Id == building.Id);
            if (houseDb == null)
                return Result<long>.Fail($"Building Not Found.");

            houseDb = _mapper.Map(building, houseDb);
            await _buildingRepository.UpdateAsync(houseDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(houseDb.Id, "Building updated successfully");
        }

        public async Task<Wrappers.IResult> DeleteBuilding(long id)
        {
            var building = await _buildingRepository.GetByIdAsync(id);
            if (building == null)
                return Result<long>.Fail("No building Found");

            if (_buildingFloorRepository.Entities.Any(b => b.BuildingId == id))
                return Result<long>.Fail("Building has one or more floors linked to it");

            building.IsDeleted = true;
            await _buildingRepository.UpdateAsync(building);
            await _unitOfWork.Commit();
            return Result<long>.Success(building.Id, "Building deleted successfully");
        }

        public async Task<Result<List<BuildingDto>>> GetAllBuildings(long blockId)
        {
            var house = await _buildingRepository.Entities.Where(s => s.Blockid == blockId).ToListAsync();
            return await Result<List<BuildingDto>>.SuccessAsync(_mapper.Map<List<BuildingDto>>(house));
        }

        public async Task<Result<List<BuildingDto>>> GetAllBuildings()
        {
            var house = await _buildingRepository.Entities.ToListAsync();
            return await Result<List<BuildingDto>>.SuccessAsync(_mapper.Map<List<BuildingDto>>(house));
        }

        public async Task<Result<List<LiteEntityDto>>> GetAllBuildingsLite(long blockId)
        {
            var orgs = await _buildingRepository.GetAllAsync();
            orgs = orgs.Where(s => s.Blockid == blockId).ToList();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(orgs));
        }

        public async Task<Result<BuildingDto>> GetBuildingById(long id)
        {
            var org = await _buildingRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<BuildingDto>.FailAsync("Building not found");
            return await Result<BuildingDto>.SuccessAsync(_mapper.Map<BuildingDto>(org));
        }

        #endregion

        #region Floor
        public async Task<Wrappers.IResult> AddBuildingFloor(BuildingFloorDto floor)
        {
            await _buildingFloorRepository.AddAsync(_mapper.Map<BuildingFloor>(floor));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Floor Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateBuildingFloor(BuildingFloorDto floor)
        {
            var floorDb = await _buildingFloorRepository.Entities.FirstOrDefaultAsync(s => s.Id == floor.Id);
            if (floorDb == null)
                return Result<long>.Fail($"Floor Not Found.");

            floorDb = _mapper.Map(floor, floorDb);
            await _buildingFloorRepository.UpdateAsync(floorDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(floorDb.Id, "Floor updated successfully");
        }

        public async  Task<Wrappers.IResult> DeleteBuildingFloor(long id)
        {
            var floor = await _buildingFloorRepository.GetByIdAsync(id);
            if (floor == null)
                return Result<long>.Fail("No floor Found");

            if (_roomRepository.Entities.Any(b => b.BuildingFloorId == id))
                return Result<long>.Fail("Floor has one or more rooms linked to it");

            floor.IsDeleted = true;
            await _buildingFloorRepository.UpdateAsync(floor);
            await _unitOfWork.Commit();
            return Result<long>.Success(floor.Id, "Floor deleted successfully");
        }

        public async  Task<Result<List<BuildingFloorDto>>> GetAllBuildingFloors(long buildingId)
        {
            var buildingFloors = await _buildingFloorRepository.Entities.Where(s => s.BuildingId == buildingId).ToListAsync();
            return await Result<List<BuildingFloorDto>>.SuccessAsync(_mapper.Map<List<BuildingFloorDto>>(buildingFloors));
        }

        public async Task<Result<List<BuildingFloorDto>>> GetAllBuildingFloors()
        {
            var buildingFloors = await _buildingFloorRepository.Entities.ToListAsync();
            return await Result<List<BuildingFloorDto>>.SuccessAsync(_mapper.Map<List<BuildingFloorDto>>(buildingFloors));
        }

        public async Task<Result<List<LiteEntityDto>>> GetAllFloorsLite(long buildingId)
        {
            var orgs = await _buildingFloorRepository.GetAllAsync();
            orgs = orgs.Where(s => s.BuildingId == buildingId).ToList();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(orgs));
        }

        public async Task<Result<BuildingFloorDto>> GetFloorById(long id)
        {
            var org = await _buildingFloorRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<BuildingFloorDto>.FailAsync("Floor not found");
            return await Result<BuildingFloorDto>.SuccessAsync(_mapper.Map<BuildingFloorDto>(org));
        }

        #endregion

        #region Rooms

        public async Task<Wrappers.IResult> AddRoom(RoomDto room)
        {
            await _roomRepository.AddAsync(_mapper.Map<RoomDto, Room>(room));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Room Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateRoom(RoomDto room)
        {
            var roomDb = await _roomRepository.Entities.FirstOrDefaultAsync(s => s.Id == room.Id);
            if (roomDb == null)
                return Result<long>.Fail($"room Not Found.");

            roomDb = _mapper.Map(room, roomDb);
            await _roomRepository.UpdateAsync(roomDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(roomDb.Id, "Room updated successfully");
        }

        public async Task<Wrappers.IResult> DeleteRoom(long id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
                return Result<long>.Fail("No room Found");

            room.IsDeleted = true;
            await _roomRepository.UpdateAsync(room);
            await _unitOfWork.Commit();
            return Result<long>.Success(room.Id, "Room deleted successfully");
        }

        public async Task<Result<List<RoomDto>>> GetAllRooms(long floorId)
        {
            var blocks = await _roomRepository.Entities.Where(s => s.BuildingFloorId == floorId).ToListAsync();
            return await Result<List<RoomDto>>.SuccessAsync(_mapper.Map<List<RoomDto>>(blocks));
        }

        public async Task<Result<List<RoomDto>>> GetAllRooms()
        {
            var blocks = await _roomRepository.Entities.ToListAsync();
            return await Result<List<RoomDto>>.SuccessAsync(_mapper.Map<List<RoomDto>>(blocks));
        }

        public async Task<Result<RoomDto>> GetRoomById(long id)
        {
            var org = await _roomRepository.Entities.FirstOrDefaultAsync(s => s.Id == id);
            if (org == null)
                return await Result<RoomDto>.FailAsync("Organization not found");
            return await Result<RoomDto>.SuccessAsync(_mapper.Map<RoomDto>(org));
        }

        public async Task<Result<List<LiteEntityDto>>> GetAllRoomsLite(long floorId)
        {
            var rooms = await _roomRepository.GetAllAsync();
            rooms = rooms.Where(s => s.BuildingFloorId == floorId).ToList();
            return await Result<List<LiteEntityDto>>.SuccessAsync(_mapper.Map<List<LiteEntityDto>>(rooms));
        }

        #endregion
    }
}
