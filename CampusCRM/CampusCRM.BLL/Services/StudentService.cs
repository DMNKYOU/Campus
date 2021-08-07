using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.BLL.Interfaces;
using CampusCRM.DAL;
using CampusCRM.DAL.Entities;
using CampusCRM.DAL.Interfaces;

namespace CampusCRM.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void AddStudent(StudentDTO studentDto)
        {
            if (studentDto == null)
                throw new ArgumentException();

            var student = _mapper.Map<Student>(studentDto);

            _unitOfWork.Students.Create(student);
            _unitOfWork.Save();
        }
        public void EditStudent(StudentDTO studentDto)
        {
            if (studentDto == null)
                throw new ArgumentException();

            var student = _mapper.Map<Student>(studentDto);

            _unitOfWork.Students.Update(student);
            _unitOfWork.Save();
        }
        public void DeleteStudent(int id)
        {
            _unitOfWork.Students.Delete(id);
            _unitOfWork.Save();
        }
        public StudentDTO GetStudent(int id)
        {
            var student = _unitOfWork.Students.Get(id);

            return _mapper.Map<StudentDTO>(student);
        }
        public IEnumerable<StudentDTO> GetStudents() /////DTO var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
        {
            var students = _unitOfWork.Students.GetAll();
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
