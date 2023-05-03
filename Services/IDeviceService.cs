
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IDeviceService
    {       
        Task<IResult> AddDevice(DeviceDto device);
        Task<IResult> UpdateDevice(DeviceDto device);
        Task<IResult> DeleteDevice(long id);

        Task<Result<List<DeviceDto>>> GetDevicesByOrganization(long id);

       // Task<Result<List<DeviceDto>>> GetDevicesBySector(long id);
        Task<Result<List<DeviceDto>>> GetDevicesByFloor(long id);

        Task<Result<List<DeviceDto>>> GetDevicesByBuilding(long id);
        Task<IResult> SaveDeviceTelemetry(DeviceTelemetryDto telemetry);

        Task<Result<DashboardSummary>> GetDeviceSummary(DashboardFilter filter);
        Task<Result<string>> RegidterDeviceType(DeviceTypeDto deviceType);
        Task<Result<List<DeviceDto>>> GetAllDevices();
        Task<Result<DeviceDto>> GetDeviceById(long id);
    }
}
