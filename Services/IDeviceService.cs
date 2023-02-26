
using SmartSence.DTO;
using SmartSence.Wrappers;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public interface IDeviceService
    {
        
        Task<IResult> AddDevice(DeviceDto device);
       
    }
}
