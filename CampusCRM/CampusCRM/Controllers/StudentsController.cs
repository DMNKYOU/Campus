using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;

namespace TrainingCenterCRM.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        private readonly IGroupService _groupService;

        private readonly IMapper _mapper;
        public StudentsController(IMapper _mapper, IGroupService _groupService, IStudentService _studentService)
        {
            this._mapper = _mapper;

            this._studentService = _studentService;
            this._groupService = _groupService;
        }

        // GET: StudentsController
        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            var studentsDto = _mapper.Map<IEnumerable<StudentDTO>, List<StudentModel>>(students);

            return View(studentsDto);
        }

        // GET: StudentsController/Add
        [HttpGet]
        public IActionResult Add()
        {
            var groups = _groupService.GetAll();
            ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
            ViewData["Action"] = "Add";

            return View("Edit", new StudentModel());
        }

        // POST: StudentsController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentModel student)
        {
            student.Name = student.Name.Trim();
            student.Surname = student.Surname.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                var groups = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
                ViewData["Action"] = "Add";
                return View("Edit",student);
            }
            _studentService.Add(_mapper.Map<StudentDTO>(student));

            return RedirectToAction("Index", "Students");
        }

        // GET: StudentsController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetById(id);
            var groups = _groupService.GetAll();
            ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
            ViewData["Action"] = "Edit";

            return View(_mapper.Map<StudentModel>(student));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel student)
        {
            student.Name = student.Name.Trim();
            student.Surname = student.Surname.Trim();
            if (!ModelState.IsValid)
            {
                //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                var groups = _groupService.GetAll();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
                ViewData["Action"] = "Edit";
                return View(student);
            }
            _studentService.Edit(_mapper.Map<StudentDTO>(student));

            return RedirectToAction("Index", "Students");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index", "Students");
        }
    }
}
