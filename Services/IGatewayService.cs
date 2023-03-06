
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IGatewayService
    {       
        Task<IResult> AddGateway(GatewayDto Gateway);
        Task<IResult> UpdateGateway(GatewayDto Gateway);
        Task<IResult> DeleteGateway(GatewayDto Gateway);

        Task<Result<List<GatewayDto>>> GetGatewaysByOrganization(long id);
        //Task<Result<List<GatewayDto>>> GetGatewaysByFloor(long id);

        //Task<Result<List<GatewayDto>>> GetGatewaysByHouse(long id);
       
    }
}
