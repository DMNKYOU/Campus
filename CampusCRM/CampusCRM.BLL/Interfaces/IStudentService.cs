using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;

namespace CampusCRM.BLL.Interfaces
{
    public interface IStudentService: IEntityService<StudentDTO>
    {
        //void AddStudent(StudentDTO studentDto);
        //void EditStudent(StudentDTO studentDto);
        //void DeleteStudent(int id);
        //StudentDTO GetStudent(int id);
        //IEnumerable<StudentDTO> GetStudents();
        //void Dispose();
        Task DeleteStudentFromGroupAsync(int groupId);
        Task AddStudentToGroupAsync(int studentId, int groupId);

    }
}
