using AutoMapper;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}