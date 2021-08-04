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
            CreateMap<StudentDTO, Student>().ReverseMap();

            CreateMap<StudentDTO, StudentModel>().ReverseMap();

        }
    }
}
