
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
        Task<IResult> SaveDeviceTelemetry(int deviveId, JsonContent content);

    }
}
