using Microsoft.AspNetCore.Mvc;
using SmartSence.DTO;
using SmartSence.Services;

namespace SmartSence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _GatewayService;

      

        public GatewayController( IGatewayService GatewayService)
        {
            _GatewayService = GatewayService;
        }


        [HttpPost]
        public async Task<IActionResult> AddGateway(GatewayDto Gateway) => Ok(await _GatewayService.AddGateway(Gateway));

        [HttpPut]
        public async Task<IActionResult> UpdateGateway(GatewayDto Gateway) => Ok(await _GatewayService.UpdateGateway(Gateway));

        [HttpGet("ByOrganization/{id}")]
        public async Task<IActionResult> GetGateways(long id) => Ok(await _GatewayService.GetGatewaysByOrganization(id));

        //[HttpGet("ByFloor/{id}")]
        //public async Task<IActionResult> GetGatewaysByFloorId(long houseId) => Ok(await _GatewayService.GetGatewaysByFloor(houseId));


        //[HttpGet("ByHouse/{id}")]
        //public async Task<IActionResult> GetGatewaysByHouseId(long houseId) => Ok(await _GatewayService.GetGatewaysByHouse(houseId));

        [HttpPost("GetGatewaySummary")]
        public async Task<IActionResult> GetGatewaySummary(DashboardFilter filter) => Ok(await _GatewayService.GetGatewaySummary(filter));


    }
}