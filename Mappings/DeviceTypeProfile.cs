using AutoMapper;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace SmartSence.Mappings
{
    public class DeviceTypeProfile : Profile
    {
        public DeviceTypeProfile()
        {
            CreateMap<DeviceTypeDto, DeviceType>().ReverseMap();
            CreateMap<DeviceTypeColumnDto, DeviceTypeColumn>().ReverseMap();
        }

    }
}
