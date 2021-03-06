using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.WebApiA.Models;

namespace CampusCRM.WebApiA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        private readonly IMapper mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;

            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<StudentModel>> GetStudents()
        {
            return mapper.Map<List<StudentModel>>(await studentService.GetAllAsync());
        }
    }
}