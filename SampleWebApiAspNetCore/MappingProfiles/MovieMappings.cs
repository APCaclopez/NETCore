using AutoMapper;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Entities;

namespace SampleWebApiAspNetCore.MappingProfiles
{
    public class MovieMappings : Profile
    {
        public MovieMappings()
        {
            CreateMap<MovieEntity, MovieDto>().ReverseMap();
            CreateMap<MovieEntity, MovieUpdateDto>().ReverseMap();
            CreateMap<MovieEntity, MovieCreateDto>().ReverseMap();
        }
    }
}
