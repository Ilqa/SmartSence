using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDto, DeviceInfo>().ReverseMap();
        }
    }
}