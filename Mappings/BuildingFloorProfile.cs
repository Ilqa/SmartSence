using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<BuildingDto, Building>().ReverseMap();
        }
    }
}