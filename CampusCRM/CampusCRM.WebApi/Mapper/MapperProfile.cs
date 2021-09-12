using AutoMapper;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.WebApi.Dto;

namespace CampusCRM.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, CourseDto>()
               // .ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
            CreateMap<StudentDTO, Student>().ForMember(destination => destination.Group,
                    opts => opts.MapFrom(source => source.Group))
                .ReverseMap();
            
        }
    }
}
