using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using CampusCRM.Contexts;
using CampusCRM.Interfaces;
using CampusCRM.Models;
using CampusCRM.Repository;

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

        //// GET: StudentsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StudentsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: StudentsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: StudentsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: StudentsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _studentRepository.Delete(id);

            return RedirectToAction("Index", "Students");
        }
    }
}