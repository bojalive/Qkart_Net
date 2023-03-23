using AutoMapper;
using CameronTubeAPI.DTO;
using CameronTubeAPI.Models;

namespace CameronTubeAPI.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Video, VideoDTO>().ReverseMap();

            CreateMap<Video, VideoCreateDTO>().ReverseMap();
        }
    }
}
