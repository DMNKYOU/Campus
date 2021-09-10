using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;


namespace CampusCRM.BLL.Interfaces
{
    public interface IGroupService : IEntityService<GroupDTO>
    {
        //void AddGroup(GroupDTO groupDto);
        //void EditGroup(GroupDTO groupDto);
        //void DeleteGroup(int id);
        //GroupDTO GetGroup(int id);
        //IEnumerable<GroupDTO> GetGroups();
        //void Dispose();        Task AddAsync(Group group, List<int> studentsId);
        Task AddGroupWithSelectedStudentsAsync(GroupDTO group, List<int> studentsId);
        Task EditGroupWithSelectedStudentsAsync(GroupDTO group, List<int> studentsId);
        Task<IEnumerable<StudentDTO>> GetStudentsWithGroupAsync(int groupId, int courseId);
    }
}
