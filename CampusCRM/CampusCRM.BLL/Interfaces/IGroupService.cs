using System.Collections.Generic;
using System.Threading.Tasks;
using CampusCRM.BLL.ModelsDTO;
using CampusCRM.DAL.Entities;


namespace CampusCRM.BLL.Interfaces
{
    public interface IGroupService : IEntityService<GroupDTO>
    {
        //Task AddStudentsToGroupAsync(GroupDTO group, List<int> studentsId);
        //Task UpdateStudentsInGroupAsync(GroupDTO group, List<int> studentsId);
        Task AddAsync(GroupDTO groupDto, List<int> studentsId);
        Task EditAsync(GroupDTO groupDto, List<int> studentsId);
    }
}
