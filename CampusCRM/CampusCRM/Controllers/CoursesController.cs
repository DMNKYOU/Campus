using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CampusCRM.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITopicService _topicService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CoursesController(IMapper mapper, ICourseService courseService, ITopicService topicService, ILogger<CoursesController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _courseService = courseService;
            _topicService = topicService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var courses = _mapper.Map<List<CourseDTO>, List<CourseModel>>(await _courseService.GetAllAsync());

                return View(courses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int? id)
        {   
            try
            {
                ViewData["Topics"] = await _topicService.GetAllAsync();
                var course = id.HasValue ? _mapper.Map<CourseModel>(await _courseService.GetByIdAsync(id.Value)) : new CourseModel();
                return View(course);
            }
            catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(CourseModel courseModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var course = _mapper.Map<CourseDTO>(courseModel);

                    if (course.Id == 0)
                        await _courseService.AddAsync(course);
                    else
                        await _courseService.EditAsync(course);

                    return RedirectToAction("Index");
                }

                ViewData["Topics"] = await _topicService.GetAllAsync();
                return View(courseModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _courseService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
