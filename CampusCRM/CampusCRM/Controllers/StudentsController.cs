using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using CampusCRM.MVC.Models;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;


namespace CampusCRM.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        private readonly IMapper _mapper;
        public StudentsController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper;

            _studentService = studentService;
        }

        // GET: StudentsController
        public ActionResult Index()
        {
            var students = _studentService.GetStudents();
            var studentsVModels = _mapper.Map<IEnumerable<StudentDTO>, List<StudentModel>>(students);

            return View(studentsVModels);
        }

        // GET: StudentsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit");
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel student)
        {
            student.Name = student.Name.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" INFO state = {ModelState.IsValid}");
                return View(student);
            }

            _studentService.AddStudent(_mapper.Map<StudentDTO>(student));

            return RedirectToAction("Index");
        }

        // GET: StudentsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = _studentService.GetStudent(id);

            return View(_mapper.Map<StudentModel>(student));

        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentModel student)
        {
            student.Name = student.Name.Trim();
            if (!ModelState.IsValid)
            {
                Debug.WriteLine($" INFO notstate = {ModelState.IsValid}");
                return View(student);
            }
            //Debug.WriteLine($" INFO +state = {ModelState.IsValid}");
            _studentService.EditStudent(_mapper.Map<StudentDTO>(student));

            return RedirectToAction("Index");
            
        }

        // GET: StudentsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);

            return RedirectToAction("Index");
        }
    }
}
