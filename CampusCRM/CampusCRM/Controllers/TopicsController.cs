using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.MVC.Models;

namespace CampusCRM.Controllers
{
    [Authorize]
    public class TopicsController : Controller
    {
        private readonly ITopicService _topicService;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TopicsController(IMapper mapper, ITopicService topicService, ILogger<TopicsController> logger)
        {
            _mapper = mapper;
            _logger = logger;

            _topicService = topicService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var topics = _mapper.Map<List<TopicDTO>, List<TopicModel>>(await _topicService.GetAllAsync());

                return View(topics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTopicAsync(int? id)
        {
            try
            {
                var topicModel = id.HasValue ?
                    _mapper.Map<TopicModel>(await _topicService.GetByIdAsync(id.Value)) : new TopicModel();

                return View(topicModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditTopicAsync(TopicModel topicModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var topic = _mapper.Map<TopicDTO>(topicModel);
                    if (topic.Id == 0)
                        await _topicService.AddAsync(topic);
                    else
                        await _topicService.EditAsync(topic);

                    return RedirectToAction("Index", "Topics");
                }

                return View(topicModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTopicAsync(int id)
        {
            try
            {
                await _topicService.DeleteAsync(id);
                return RedirectToAction("Index", "Topics");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
