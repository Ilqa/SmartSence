using AutoMapper;
//using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartSence.Database.Entities;
using SmartSence.Database.Repositories;
using SmartSence.Databse.Entities;
using SmartSence.DTO;
using SmartSence.Wrappers;

namespace SmartSence.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryAsync<Gateway> _repositoryAsync;
        


        public GatewayService( IMapper mapper, IUnitOfWork unitOfWork, IRepositoryAsync<Gateway> repositoryAsync)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Wrappers.IResult> AddGateway(GatewayDto Gateway)
        {
            await _repositoryAsync.AddAsync(_mapper.Map<Gateway>(Gateway));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Gateway Added Successfully");
        }

        public Task<Wrappers.IResult> DeleteGateway(GatewayDto Gateway)
        {
            throw new NotImplementedException();
        }


        //public async Task<Result<List<GatewayDto>>> GetGatewaysByHouse(long id)
        //{
        //    var Gateways = await _repositoryAsync.Entities.Where(s => s.BuildingFloor.BuildingId == id).ToListAsync();
        //    return await Result<List<GatewayDto>>.SuccessAsync(_mapper.Map<List<GatewayDto>>(Gateways));
        //}

        public async Task<Result<List<GatewayDto>>> GetGatewaysByOrganization(long id)
        {
            var Gateways = await _repositoryAsync.Entities.Where(s => s.Orgid == id).ToListAsync();
            return await Result<List<GatewayDto>>.SuccessAsync(_mapper.Map<List<GatewayDto>>(Gateways));
        }

        public async Task<Wrappers.IResult> UpdateGateway(GatewayDto Gateway)
        {
            var GatewayDb = await _repositoryAsync.Entities.FirstOrDefaultAsync(s => s.Id == Gateway.Id);
            if (GatewayDb == null)
                return Result<long>.Fail($"Gateway Not Found.");

            GatewayDb = _mapper.Map(Gateway, GatewayDb);
            await _repositoryAsync.UpdateAsync(GatewayDb);
            await _unitOfWork.Commit();
            return Result<long>.Success(GatewayDb.Id, "Gateway updated successfully");
        }
    }
}
