using Microsoft.AspNetCore.Mvc;
using SmartSence.DTO;
using SmartSence.Services;

namespace SmartSence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _orgService;

        private readonly ILogger<OrganizationController> _logger;

        public DeviceController(ILogger<OrganizationController> logger, IDeviceService orgService)
        {
            _orgService = orgService;
        }


        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceDto org) => Ok(await _orgService.AddDevice(org));
    }
}