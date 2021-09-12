using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CampusCRM.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;

        private readonly ITeacherService _teacherService;

        private readonly ICourseService _courseService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public GroupsController(IMapper mapper, IGroupService groupService, ITeacherService teacherService, ICourseService courseService,
            ILogger<GroupsController> logger)
        {
            _mapper = mapper;
            _logger = logger;

            _groupService = groupService;
            _teacherService = teacherService;
            _courseService = courseService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var groups = await _groupService.GetAllAsync();
                var groupsDto = _mapper.Map<List<GroupDTO>, List<GroupModel>>(groups);

                return View(groupsDto);
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
                var groupModel = id.HasValue ?
                    _mapper.Map<GroupModel>(await _groupService.GetByIdAsync(id.Value)) :
                    new GroupModel() { StartDate = DateTime.Today };

                ViewBag.Teachers = await _teacherService.GetAllAsync();
                ViewBag.Courses = await _courseService.GetAllAsync();

                return View(groupModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddAsync(int? id)
        {
            try
            {
                var groupModel = id.HasValue ?
                    _mapper.Map<GroupModel>(await _groupService.GetByIdAsync(id.Value)) :
                    new GroupModel() { StartDate = DateTime.Today };

                ViewBag.Teachers = await _teacherService.GetAllAsync();
                ViewBag.Courses = await _courseService.GetAllAsync();

                return View("Edit", groupModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(GroupModel groupModel, List<int> studentsId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Debug.WriteLine($"Пришло студентов {studentsId.Count}");
                    var group =_mapper.Map<GroupDTO>(groupModel);

                    if (group.Id == 0)
                        await _groupService.AddAsync(group, studentsId);
                    else
                    {
                       // Debug.WriteLine("Edit start");
                        await _groupService.EditAsync(group, studentsId);

                    }

                    return RedirectToAction("Index", "Groups");
                }

                ViewBag.Courses = await _courseService.GetAllAsync();
                ViewBag.Teachers = await _teacherService.GetAllAsync();
                return View(groupModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> AddAsync()
        //{
        //    var teachers = await _teacherService.GetAllAsync();
        //    ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);

        //    ViewData["Action"] = "Add";

        //    return View("Edit", new GroupModel());
        //}
        //
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> AddAsync(GroupModel group)
        //{
        //    group.Name = group.Name.Trim();
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
        //            var teachers = await _teacherService.GetAllAsync();
        //            ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);

        //            ViewData["Action"] = "Add";
        //            return View("Edit", group);
        //        }

        //        await _groupService.AddAsync(_mapper.Map<GroupDTO>(group));

        //        return RedirectToAction("Index", "Groups");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet]
        //[Authorize(policy: "ManageAndDevDepart")]
        //public IActionResult Edit(int id)
        //{
        //    var groupDto = _groupService.GetById(id);
        //    var teachers = _teacherService.GetAll();
        //    ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);
        //    ViewData["Action"] = "Edit";

        //    return View(_mapper.Map<GroupModel>(groupDto));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(policy: "ManageAndDevDepart")]
        //public IActionResult Edit(GroupModel group)
        //{
        //    group.Name = group.Name.Trim();
        //    if (!ModelState.IsValid)
        //    {
        //        //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
        //        var teachers = _teacherService.GetAll();
        //        ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);
        //        ViewData["Action"] = "Edit";

        //        return View("Edit", group);
        //    }
        //    _groupService.Edit(_mapper.Map<GroupDTO>(group));

        //    return RedirectToAction("Index", "Groups");
        //}

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _groupService.DeleteAsync(id);

                return RedirectToAction("Index", "Groups");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
