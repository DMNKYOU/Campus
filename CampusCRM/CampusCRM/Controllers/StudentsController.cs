using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using CampusCRM.Contexts;
using CampusCRM.Models;

namespace CampusCRM.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _studentRepository;
        public StudentsController(CampusContext context)
        {
            _studentRepository = new StudentsRepository(context);
        }
        // GET: StudentsController
        public ActionResult Index()
        {
            var students = _studentRepository.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>()).CreateMapper();
            var studentsVModels = mapper.Map<IEnumerable<Student>, List<StudentModel>>(students);

            return View(studentsVModels);
        }

        // GET: StudentsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
            _studentRepository.Create(new Student() {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
            });

            return RedirectToAction("Index", "Students");
        }

        // GET: StudentsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var studentDto = _studentRepository.Get(id);

            var student = new StudentModel()
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                Surname = studentDto.Surname,
                Age = studentDto.Age
            };
            
            return View(student);
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
            Debug.WriteLine($" INFO +state = {ModelState.IsValid}");
            _studentRepository.Update(new Student()
           {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age
           });
            
           return RedirectToAction("Index", "Students");
            
        }

        // GET: StudentsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _studentRepository.Delete(id);

            return RedirectToAction("Index", "Students");
        }
    }
}
