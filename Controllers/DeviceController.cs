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
        public async Task<IActionResult> GetDevices(long orgId) => Ok(await _deviceService.GetDevicesByOrganization(orgId));

        [HttpGet("ByBuilding/{id}")]
        public async Task<IActionResult> GetDevicesByBuildingId(long houseId) => Ok(await _deviceService.GetDevicesByHouse(houseId));

        [HttpGet("ByFloor/{id}")]
        public async Task<IActionResult> GetDevicesByHouseId(long houseId) => Ok(await _deviceService.GetDevicesByFloor(houseId));
    }
}