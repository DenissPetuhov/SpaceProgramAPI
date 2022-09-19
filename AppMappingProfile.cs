using AutoMapper;
using SpaceProgram.EFCore;
using SpaceProgram.Model;

namespace SpaceProgram
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<SpaceObjectModel, SpaceObject>().ReverseMap();
            CreateMap<SpaceSystemModel, SpaceSystem>().ReverseMap();
        }
    }
}
