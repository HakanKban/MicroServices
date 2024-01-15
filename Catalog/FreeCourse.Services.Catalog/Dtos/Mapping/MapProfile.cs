using AutoMapper;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Dtos.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course,CourseUpdateDto>().ReverseMap();
            CreateMap<Course,CourseCreateDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

        }
    }
}
