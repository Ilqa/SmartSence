using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepositoryAsync<Organization> _organizationRepository;
        private readonly IRepositoryAsync<Sector> _sectorRepository;
        private readonly IRepositoryAsync<Block> _blockRepository;
        private readonly IRepositoryAsync<House> _houseRepository;
       
        private readonly IUnitOfWork _unitOfWork;


        public OrganizationService(IRepositoryAsync<Organization> organizationRepository, IRepositoryAsync<House> houseRepository, IRepositoryAsync<Sector> sectorRepository, IRepositoryAsync<Block> blockRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            //_roleManager = roleManager;
            _sectorRepository = sectorRepository;
            _blockRepository = blockRepository;
            _houseRepository = houseRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Wrappers.Result<List<OrganizationDto>>> GetAllOrganizations()
        {
            var orgs = await _organizationRepository.GetAllAsync();
            return await Result<List<OrganizationDto>>.SuccessAsync(_mapper.Map<List<OrganizationDto>>(orgs));
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

        public Task<Wrappers.IResult> DeleteOrganization(long id)
        {
            throw new NotImplementedException();
        }

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

            //sector.IsDeleted = true;
            //sector.DeletedOn = DateTime.UtcNow;
            await _sectorRepository.UpdateAsync(sector);
            await _unitOfWork.Commit();
            return Result<long>.Success(sector.Id, "Sector deleted successfully");
        }

        public async Task<Result<List<SectorDto>>> GetAllSectors(long orgId)
        {
            var sectors = await _sectorRepository.Entities.Where(s => s.Orgid== orgId).ToListAsync();
            return await Result<List<SectorDto>>.SuccessAsync(_mapper.Map<List<SectorDto>>(sectors));
        }

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

        public Task<Wrappers.IResult> DeleteBlock(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<BlockDto>>> GetAllBlocks(long sectorId)
        {
            var blocks = await _blockRepository.Entities.Where(s => s.Sectorid == sectorId).ToListAsync();
            return await Result<List<BlockDto>>.SuccessAsync(_mapper.Map<List<BlockDto>>(blocks));
        }

        public async Task<Wrappers.IResult> AddHouse(HouseDto house)
        {
            await _houseRepository.AddAsync(_mapper.Map<House>(house));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("House Added Successfully");
        }

        public async Task<Wrappers.IResult> UpdateHouse(HouseDto house)
        {
            var houseDb = await _houseRepository.Entities.FirstOrDefaultAsync(s => s.Id == house.Id);
            if (houseDb == null)
                return Result<long>.Fail($"House Not Found.");

            houseDb = _mapper.Map(house, houseDb);
            await _houseRepository.UpdateAsync(houseDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(houseDb.Id, "House updated successfully");
        }

        public Task<Wrappers.IResult> DeleteHouse(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<HouseDto>>> GetAllHouses(long blockId)
        {
            var house = await _houseRepository.Entities.Where(s => s.Blockid == blockId).ToListAsync();
            return await Result<List<HouseDto>>.SuccessAsync(_mapper.Map<List<HouseDto>>(house));
        }
    }
}
