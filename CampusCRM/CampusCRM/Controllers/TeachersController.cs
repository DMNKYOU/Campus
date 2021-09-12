using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CampusCRM.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public TeachersController(IMapper mapper, ITeacherService teacherService, ILogger<TeachersController> logger)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var teachers = await _teacherService.GetAllAsync();
                var teachersDto = _mapper.Map<List<TeacherModel>>(teachers);
                return View(teachersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewData["Action"] = "Add";

            return View("Edit", new TeacherModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync(TeacherModel teacher)
        {
            teacher.Name = teacher.Name.Trim();
            teacher.Surname = teacher.Surname.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} {ModelState.Keys}");
                ViewData["Action"] = "Add";
                return View("Edit", teacher);
            }

            try
            {
                await _teacherService.AddAsync(_mapper.Map<TeacherDTO>(teacher));

                return RedirectToAction("Index", "Teachers");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize("ManageAndDevDepart")]
        public async Task<IActionResult> EditAsync(int id)
        {
            try
            {
                var teacherDto = await _teacherService.GetByIdAsync(id);
                ViewData["Action"] = "Edit";

                return View(_mapper.Map<TeacherModel>(teacherDto));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("ManageAndDevDepart")]
        public async Task<IActionResult> EditAsync(TeacherModel teacher)
        {
            teacher.Name = teacher.Name.Trim();
            teacher.Surname = teacher.Surname.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} {ModelState.Count}");
                ViewData["Action"] = "Edit";
                return View("Edit", teacher);
            }

            try
            {
                await _teacherService.EditAsync(_mapper.Map<TeacherDTO>(teacher));

                return RedirectToAction("Index", "Teachers");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _teacherService.DeleteAsync(id);
                return RedirectToAction("Index", "Teachers");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

    }
}