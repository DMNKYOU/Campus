using System.Collections.Generic;
using CampusCRM.WebApi.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CampusCRM.BLL.Interfaces;
using System.Threading.Tasks;

namespace AcademyCRM.Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public CoursesController(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CourseDto>> GetAll()
        {
            return _mapper.Map<List<CourseDto>>(await _service.GetAllAsync());
        }
    }
}
