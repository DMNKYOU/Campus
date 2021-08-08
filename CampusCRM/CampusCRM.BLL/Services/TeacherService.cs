using AutoMapper;
using System;
using System.Collections.Generic;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;


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
        public void AddTeacher(TeacherDTO teacherDto)
        {
            if (teacherDto == null)
                throw new ArgumentException();

            var teacher = _mapper.Map<Teacher>(teacherDto);

            _unitOfWork.Teachers.Create(teacher);
            _unitOfWork.Save();
        }

        public void DeleteTeacher(int id)
        {
            _unitOfWork.Teachers.Delete(id);
            _unitOfWork.Save();
        }


        public void EditTeacher(TeacherDTO teacherDto)
        {
            if (teacherDto == null)
                throw new ArgumentException();

            var teacher = _mapper.Map<Teacher>(teacherDto);

            _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();
        }

        public TeacherDTO GetTeacher(int id)
        {
            var teacher = _unitOfWork.Teachers.Get(id);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public IEnumerable<TeacherDTO> GetTeachers()
        {
            var teachers = _unitOfWork.Teachers.GetAll();
            return _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherDTO>>(teachers);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
