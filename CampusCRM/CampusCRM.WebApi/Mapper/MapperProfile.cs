using AutoMapper;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.WebApi.Models;

namespace CampusCRM.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, StudentModel>()
                //.ForMember(model => model.TopicName, map => map.MapFrom(c => c.Topic.Title))
                .ReverseMap();
            CreateMap<StudentDTO, Student>().ForMember(destination => destination.Group,
                    opts => opts.MapFrom(source => source.Group))
                .ReverseMap();

            CreateMap<GroupDTO, Group>().ReverseMap();

        }
    }
}
