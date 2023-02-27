using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<HouseDto, House>().ReverseMap();
        }
    }
}