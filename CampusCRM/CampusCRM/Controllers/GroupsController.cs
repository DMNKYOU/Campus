using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.MVC.Models;

namespace CampusCRM.MVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;

        private readonly ITeacherService _teacherService;

        private readonly IMapper _mapper;

        public GroupsController(IMapper mapper, IGroupService groupService, ITeacherService teacherService)
        {
            _mapper = mapper;
            _groupService = groupService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var groups = _groupService.GetAll();
            var groupsDto = _mapper.Map<IEnumerable<GroupDTO>, List<GroupModel>>(groups);

            return View(groupsDto);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var teachers = _teacherService.GetAll();
            ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);

            ViewData["Action"] = "Add";

            return View("Edit", new GroupModel());
        }

        [HttpPost]
        public IActionResult Add(GroupModel group)
        {
            group.Name = group.Name.Trim();
            if (!ModelState.IsValid)
            {
                //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                var teachers = _teacherService.GetAll();
                ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);

                ViewData["Action"] = "Add";
                return View("Edit", group);
            }
            _groupService.Add(_mapper.Map<GroupDTO>(group));

            return RedirectToAction("Index", "Groups");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var groupDto = _groupService.GetById(id);
            var teachers = _teacherService.GetAll();
            ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);
            ViewData["Action"] = "Edit";

            return View(_mapper.Map<GroupModel>(groupDto));
        }

        [HttpPost]
        public IActionResult Edit(GroupModel group)
        {
            group.Name = group.Name.Trim();
            if (!ModelState.IsValid)
            {
                //Debug.WriteLine($" From {ModelState.IsValid} { ModelState.Count}");
                var teachers = _teacherService.GetAll();
                ViewData["Teachers"] = _mapper.Map<List<TeacherModel>>(teachers);
                ViewData["Action"] = "Edit";

                return View("Edit", group);
            }
            _groupService.Edit(_mapper.Map<GroupDTO>(group));

            return RedirectToAction("Index", "Groups");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _groupService.Delete(id);

            return RedirectToAction("Index", "Groups");
        }
    }
}
