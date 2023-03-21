using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SmartSence.DTO;
using SmartSence.Services;

namespace SmartSence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        private readonly ILogger<OrganizationController> _logger;

        public DeviceController(ILogger<OrganizationController> logger, IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceDto device) => Ok(await _deviceService.AddDevice(device));

        [HttpPut]
        public async Task<IActionResult> UpdateDevice(DeviceDto device) => Ok(await _deviceService.UpdateDevice(device));

        [HttpGet("ByOrganization/{id}")]
        public async Task<IActionResult> GetDevices(long id) => Ok(await _deviceService.GetDevicesByOrganization(id));

        //[HttpGet("BySector/{id}")]
        //public async Task<IActionResult> GetDevicesBySector(long sectorId) => Ok(await _deviceService.GetDevicesByOrganization(orgId));

        [HttpGet("ByBuilding/{id}")]
        public async Task<IActionResult> GetDevicesByBuildingId(long houseId) => Ok(await _deviceService.GetDevicesByHouse(houseId));

        [HttpGet("ByFloor/{id}")]
        public async Task<IActionResult> GetDevicesByHouseId(long houseId) => Ok(await _deviceService.GetDevicesByFloor(houseId));

        [HttpPost("DeviceTelemetry")]
        public async Task<IActionResult> SaveDeviceTelemetry(DeviceTelemetryDto telemetry) => Ok(await _deviceService.SaveDeviceTelemetry(telemetry));

        [HttpPost("GetDeviceSummary")]
        public async Task<IActionResult> GetDeviceSummary(DashboardFilter filter) => Ok(await _deviceService.GetDeviceSummary(filter));

        

    }
}