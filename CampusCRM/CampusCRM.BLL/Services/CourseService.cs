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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CourseDTO>> GetAllAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<Course>, List<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> GetByIdAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetAsync(id);

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task AddAsync(CourseDTO courseDto)
        {
            if (courseDto == null)
                throw new ArgumentException();

            var course = _mapper.Map<Course>(courseDto);

            await _unitOfWork.Courses.CreateAsync(course);
            //_unitOfWork.Save();
        }

        public async Task EditAsync(CourseDTO courseDto)
        {
            if (courseDto == null)
                throw new ArgumentException();

            var course = _mapper.Map<Course>(courseDto);

            await _unitOfWork.Courses.UpdateAsync(course);
            //_unitOfWork.Save();
        }  
        
       
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Courses.DeleteAsync(id);
            //_unitOfWork.Save();
        } 
        
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}
