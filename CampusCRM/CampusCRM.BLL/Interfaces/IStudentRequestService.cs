using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.BLL.Interfaces;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;


namespace CampusCRM.BLL.Interfaces
{
    public interface IStudentRequestService : IEntityService<StudentRequestDTO>
    {
        Task<List<StudentRequestDTO>> GetOpenRequestsAsync();
        Task<List<StudentRequestDTO>> GetOpenRequestsByCourseAsync(int courseId);
        Task<IEnumerable<StudentDTO>> GetStudentsRequestedForCourseAsync(int courseId);
        Task CloseRequestsAsync(List<int> studentsId, int courseId);
    }
}
