using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;

namespace CampusCRM.BLL.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(StudentDTO studentDto);
        void EditStudent(StudentDTO studentDto);
        void DeleteStudent(int id);
        StudentDTO GetStudent(int id);
        IEnumerable<StudentDTO> GetStudents();
        void Dispose();
    }
}
