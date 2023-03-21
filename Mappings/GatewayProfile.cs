using AutoMapper;
using SmartSence.Database.Entities;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class GatewayProfile : Profile
    {
        public GatewayProfile()
        {
            CreateMap<GatewayDto, Gateway>().ReverseMap();
            //CreateMap<LiteEntityDto, Block>().ReverseMap();
        }
    }
}