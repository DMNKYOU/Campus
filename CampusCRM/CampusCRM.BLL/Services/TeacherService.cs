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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TeacherDTO>> GetAllAsync()
        {
            var teachers = await _unitOfWork.Teachers.GetAllAsync();
            return _mapper.Map<IEnumerable<Teacher>, List<TeacherDTO>>(teachers);
        }

        public async Task<TeacherDTO> GetByIdAsync(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetAsync(id);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task AddAsync(TeacherDTO teacherDto)
        {
            if (teacherDto == null)
                throw new ArgumentException();

            var teacher = _mapper.Map<Teacher>(teacherDto);

            await _unitOfWork.Teachers.CreateAsync(teacher);
            //_unitOfWork.Save();
        }

        public async Task EditAsync(TeacherDTO teacherDto)
        {
            if (teacherDto == null)
                throw new ArgumentException();

            var teacher = _mapper.Map<Teacher>(teacherDto);

            await _unitOfWork.Teachers.UpdateAsync(teacher);
            //_unitOfWork.Save();
        }  
        
       
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Teachers.DeleteAsync(id);
            //_unitOfWork.Save();
        } 
        
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}
