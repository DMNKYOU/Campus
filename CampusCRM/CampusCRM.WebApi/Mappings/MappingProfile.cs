using AutoMapper;
using System;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.WebApi.Models;

namespace CampusCRM.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, Student>().ForMember(destination => destination.Group,
                    opts => opts.MapFrom(source => source.Group))
                .ReverseMap();

            CreateMap<StudentDTO, StudentModel>().ForMember(destination => destination.GroupName,
                    opts => opts.MapFrom(source => source.Group.Name))
                .ReverseMap();

            CreateMap<GroupDTO, Group>().ReverseMap();

            //CreateMap<GroupDTO, Group>().ReverseMap();
            //CreateMap<GroupDTO, GroupModel>().ReverseMap();


            //CreateMap<TeacherDTO, Teacher>().ReverseMap();
            //CreateMap<TeacherDTO, TeacherModel>().ReverseMap();

            //CreateMap<StudentRequest, StudentRequestDTO>().ReverseMap();
            //CreateMap<StudentRequestDTO, StudentRequestModel>()
            //    .ForMember(sr => sr.Status, map => map.MapFrom(sr => sr.Status))
            //    .ReverseMap();

            //CreateMap<Course, CourseDTO>().ReverseMap();
            //CreateMap<CourseDTO, CourseModel>().ReverseMap();

            //CreateMap<Topic, TopicDTO>().ReverseMap();
            //CreateMap<TopicDTO, TopicModel>().ReverseMap();

        }
    }
}
