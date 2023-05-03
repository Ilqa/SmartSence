using AutoMapper;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class BuildingFloorProfile : Profile
    {
        public BuildingFloorProfile()
        {
            CreateMap<BuildingFloor, BuildingFloorDto>().ReverseMap();
            CreateMap<LiteEntityDto, BuildingFloor>().ReverseMap();
        }
    }
}