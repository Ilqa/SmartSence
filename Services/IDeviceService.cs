
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IDeviceService
    {       
        Task<IResult> AddDevice(DeviceDto device);
        Task<IResult> UpdateDevice(DeviceDto device);
        Task<IResult> DeleteDevice(DeviceDto device);

        Task<Result<List<DeviceDto>>> GetDevicesByOrganization(long id);
        Task<Result<List<DeviceDto>>> GetDevicesByFloor(long id);

        Task<Result<List<DeviceDto>>> GetDevicesByHouse(long id);
        Task<IResult> SaveDeviceTelemetry(int deviveId, JsonContent content);

    }
}
