using AutoMapper;
using SmartSence.Databse.Entities;
using SmartSence.DTO;

namespace JobHunt.Mappings
{
    public class BlockProfile : Profile
    {
        public BlockProfile()
        {
            CreateMap<BlockDto, Block>().ReverseMap();
            CreateMap<LiteEntityDto, Block>().ReverseMap();
        }
    }
}