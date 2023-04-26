using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDto, Device>().ReverseMap();
            CreateMap<DeviceTelemetryDto, DeviceTelemetry>()
                .ForMember(dest => dest.DeviceTx, opt => opt.MapFrom(src => src.DeviceTx.ToString()))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data.ToString()))
                .ForMember(dest => dest.GatewayRx, opt => opt.MapFrom(src => src.GatewayRx.ToString()));
    
        }
    }
}