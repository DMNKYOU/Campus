using AutoMapper;
using System;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;

namespace CampusCRM.MVC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, Student>().ForMember(destination => destination.Group,
                    opts => opts.MapFrom(source => source.Group))
                .ReverseMap();

            CreateMap<StudentDTO, StudentModel>().ReverseMap();

            CreateMap<GroupDTO, Group>().ReverseMap();

            CreateMap<GroupDTO, GroupModel>().ReverseMap();


            CreateMap<TeacherDTO, Teacher>().ReverseMap();
            CreateMap<TeacherDTO, TeacherModel>().ReverseMap();
        }
    }
}
