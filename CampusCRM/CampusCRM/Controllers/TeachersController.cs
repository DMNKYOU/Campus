using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.MVC.Models;


namespace CampusCRM.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        private readonly IMapper _mapper;

        public TeachersController(IMapper mapper, ITeacherService teacherService)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var teachers = _teacherService.GetAll();
            var teachersDto = _mapper.Map<List<TeacherModel>>(teachers);

            return View(teachersDto);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Action"] = "Add";

            return View("Edit", new TeacherModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(TeacherModel teacher)
        {
            teacher.Name = teacher.Name.Trim();
            teacher.Surname = teacher.Surname.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Keys}");
                ViewData["Action"] = "Add";
                return View("Edit", teacher);
            }
            _teacherService.Add(_mapper.Map<TeacherDTO>(teacher));

            return RedirectToAction("Index", "Teachers");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacherDto = _teacherService.GetById(id);
            ViewData["Action"] = "Edit";

            return View(_mapper.Map<TeacherModel>(teacherDto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeacherModel teacher)
        {
            teacher.Name = teacher.Name.Trim();
            teacher.Surname = teacher.Surname.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                ViewData["Action"] = "Edit";
                return View("Edit", teacher);
            }
            _teacherService.Edit(_mapper.Map<TeacherDTO>(teacher));

            return RedirectToAction("Index", "Teachers");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _teacherService.Delete(id);
            return RedirectToAction("Index", "Teachers");
        }
    }
}
