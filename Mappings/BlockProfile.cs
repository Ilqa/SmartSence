using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class SectorPofile : Profile
    {
        public SectorPofile()
        {
            CreateMap<SectorDto, Sector>().ReverseMap();
        }
    }
}