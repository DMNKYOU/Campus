using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CampusCRM.MvcOptions.Controllers.API
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        private readonly IGroupService _groupService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public StudentsController(IMapper _mapper, IGroupService _groupService, IStudentService _studentService, ILogger<StudentsController> logger)
        {
            this._mapper = _mapper;

            this._studentService = _studentService;
            this._groupService = _groupService;
        }

        // GET: StudentsController
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var students = await _studentService.GetAllAsync();
               var resList = _mapper.Map<List<StudentDTO>, List<StudentModel>>(students);

                return View(resList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        
        // GET: StudentsController/Edit/5
        
        // GET: StudentsController/Add
        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            var groups = await _groupService.GetAllAsync();
            ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
            ViewData["Action"] = "Add";

            return View("Edit", new StudentModel());
        }

        // POST: StudentsController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync(StudentModel student)
        {
            student.Name = student.Name.Trim();
            student.Surname = student.Surname.Trim();
            if (!ModelState.IsValid)
            {
               // Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                var groups = await _groupService.GetAllAsync();
                ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
                ViewData["Action"] = "Add";
                return View("Edit",student);
            }
            await _studentService.AddAsync(_mapper.Map<StudentDTO>(student));

            return RedirectToAction("Index", "Students");
        }

        [HttpGet]
        [Authorize(policy: "ManageAndDevDepart")]
        public async Task<IActionResult> EditAsync(int? id)
        {
            try
            {
                var studentModel = id.HasValue
                    ? _mapper.Map<StudentModel>(await _studentService.GetByIdAsync(id.Value))
                    : new StudentModel();

                ViewBag.Groups = _mapper.Map<List<GroupDTO>, List<GroupModel>>(await _groupService.GetAllAsync());
                ViewData["Action"] = "Edit";

                return View(studentModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(policy: "ManageAndDevDepart")]
        public async Task<IActionResult> EditAsync(StudentModel studentModel)
        {
            try
            {
                //Debug.WriteLine($"RESAULT groupID in student = {studentModel.GroupId}");
                //Debug.WriteLine($"RESAULT IsValid= {ModelState.IsValid}");
                studentModel.Name = studentModel.Name.Trim();
                studentModel.Surname = studentModel.Surname.Trim();

                if (!ModelState.IsValid)
                {
                    //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                    var groups = await _groupService.GetAllAsync();
                    ViewBag.Groups = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);
                    ViewData["Action"] = "Edit";
                    return View(studentModel);
                }

                var student = _mapper.Map<StudentDTO>(studentModel);

                if (student.Id == 0)
                {                                                            //для ролей сделаю в отедльном/////////////////////
                    await _studentService.AddAsync(student);
                }
                else
                {
                    await _studentService.EditAsync(student);
                    // throw new Exception(); тест
                }

                return RedirectToAction("Index", "Students");
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
                await _studentService.DeleteAsync(id);
                return RedirectToAction("Index", "Students");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
