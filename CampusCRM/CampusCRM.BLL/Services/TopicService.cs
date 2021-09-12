using AutoMapper;
using System;
using System.Collections.Generic;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;
using System.Threading.Tasks;

namespace CampusCRM.BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TopicDTO>> GetAllAsync()
        {
            var topics = await _unitOfWork.Topics.GetAllAsync();
            return _mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(topics);
        }

        public async Task<TopicDTO> GetByIdAsync(int id)
        {
            var topic = await _unitOfWork.Topics.GetAsync(id);

            return _mapper.Map<TopicDTO>(topic);
        }

        public async Task AddAsync(TopicDTO topicDto)
        {
            if (topicDto == null)
                throw new ArgumentException();

            var topic = _mapper.Map<Topic>(topicDto);

            await _unitOfWork.Topics.CreateAsync(topic);
            //_unitOfWork.Save();
        }

        public async Task EditAsync(TopicDTO topicDto)
        {
            if (topicDto == null)
                throw new ArgumentException();

            var topic = _mapper.Map<Topic>(topicDto);

            await _unitOfWork.Topics.UpdateAsync(topic);
            //_unitOfWork.Save();
        }  
        
       
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Topics.DeleteAsync(id);
            //_unitOfWork.Save();
        } 
        
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}
