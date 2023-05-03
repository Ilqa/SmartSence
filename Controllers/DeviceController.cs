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

        [HttpGet("AllDevices")]
        public async Task<IActionResult> GetAllDevices() => Ok(await _deviceService.GetAllDevices());

        [HttpGet("DeviceById/{id}")]
        public async Task<IActionResult> GetDeviceById(long id) => Ok(await _deviceService.GetDeviceById(id));

        [HttpGet("ByOrganization/{id}")]
        public async Task<IActionResult> GetDevices(long id) => Ok(await _deviceService.GetDevicesByOrganization(id));

        //[HttpGet("BySector/{id}")]
        //public async Task<IActionResult> GetDevicesBySector(long sectorId) => Ok(await _deviceService.GetDevicesByOrganization(orgId));

        [HttpGet("ByBuilding/{id}")]
        public async Task<IActionResult> GetDevicesByBuildingId(long houseId) => Ok(await _deviceService.GetDevicesByBuilding(houseId));

        [HttpGet("ByFloor/{id}")]
        public async Task<IActionResult> GetDevicesByHouseId(long houseId) => Ok(await _deviceService.GetDevicesByFloor(houseId));

        [HttpPost("DeviceTelemetry")]
        public async Task<IActionResult> SaveDeviceTelemetry(DeviceTelemetryDto telemetry) => Ok(await _deviceService.SaveDeviceTelemetry(telemetry));

        [HttpPost("GetDeviceSummary")]
        public async Task<IActionResult> GetDeviceSummary(DashboardFilter filter) => Ok(await _deviceService.GetDeviceSummary(filter));

       

        [HttpPut("DeleteDevice")]
        public async Task<IActionResult> DeleteDevice(long id) => Ok(await _deviceService.DeleteDevice(id));

        [HttpPost("RegisterDeviceType")]
        public async Task<IActionResult> RegisterDeviceType(DeviceTypeDto deviceType) => Ok(await _deviceService.RegidterDeviceType(deviceType));

        [HttpGet("MetaData_DataType")]
        public async Task<IActionResult> MetaData_DataType() => Ok(new List<string>() { "integer", "bigint", "text", "timestamp with time zone" });

        [HttpGet("AllDeviceTypes")]
        public async Task<IActionResult> GetAllDeviceTypes() => Ok(await _deviceService.GetAllDeviceTypes());

        [HttpGet("DeviceTypeById/{id}")]
        public async Task<IActionResult> GetDeviceTypeById(long id) => Ok(await _deviceService.GetDeviceTypeById(id));

    }
}