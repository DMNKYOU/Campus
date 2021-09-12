using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;


namespace CampusCRM.MVC.Controllers
{
    public class StudentRequestsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private readonly IStudentRequestService _studentRequestService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IGroupService _groupService;

        public StudentRequestsController(IMapper mapper, IStudentRequestService studentRequestService, IStudentService studentService,
                                         ICourseService courseService, IGroupService groupService, ILogger<StudentRequestsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _studentRequestService = studentRequestService;
            _studentService = studentService;
            _courseService = courseService;
            _groupService = groupService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var requests = _mapper.Map<List<StudentRequestDTO>, List<StudentRequestModel>>(await _studentRequestService.GetOpenRequestsAsync());
                return View(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditRequestAsync(int? id, int studentId)
        {
            try
            {
                var request = id.HasValue ?
                    _mapper.Map<StudentRequestModel>(await _studentRequestService.GetByIdAsync(id.Value)) :
                    new StudentRequestModel() { StartDate = DateTime.Today };

                request.Student = _mapper.Map<StudentModel>(await _studentService.GetByIdAsync(studentId));
                ViewBag.Courses = await _courseService.GetAllAsync();

                return View(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditRequestAsync(StudentRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = _mapper.Map<StudentRequestDTO>(model);

                    if (model.Id == 0)
                        await _studentRequestService.AddAsync(request);
                    else
                        await _studentRequestService.EditAsync(request);

                    return RedirectToAction("Index", "StudentRequests");
                }
                model.Student = _mapper.Map<StudentModel>(await _studentService.GetByIdAsync(model.StudentId));
                ViewBag.Courses = await _courseService.GetAllAsync();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRequestAsync(int id)
        {
            try
            {
                await _studentRequestService.DeleteAsync(id);
                return RedirectToAction("Index", "StudentRequests");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        public async Task<JsonResult> GetStudentsByCourseAsync(int courseId, int groupId)
        {
            try
            {
                Debug.WriteLine($"START GetStudentsByCourseAsync ____________________");
                var students =
                    _mapper.Map<List<StudentModel>>(await _studentRequestService.GetStudentsRequestedForCourseAsync(courseId));

                Debug.WriteLine($"START GetStudentsRequestedForCourseAsync COUNT = {students.Count} !");
                

                if (groupId != 0)
                {
                    var studentsWithGroup = _mapper.Map<List<StudentModel>>((await _groupService.GetByIdAsync(groupId)).Students);

                    foreach (var studentWithGroup in studentsWithGroup)
                    {
                        studentWithGroup.HasGroup = true;
                    }
              
                    students.AddRange(studentsWithGroup);
                }
                var res = Json(students.OrderBy(s => s.Name));
               
                foreach (StudentModel st in students) {
                    Debug.WriteLine($"res json: {st.Id}  {st.Name} {st.HasGroup} {st.GroupId}");
                }
                Debug.WriteLine($"END GetStudentsByCourseAsync ____________________");
                return Json(students.OrderBy(s => s.Name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Json("");
            }
        }
    }
}
