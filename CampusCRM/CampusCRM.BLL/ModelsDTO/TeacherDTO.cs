using System.Collections.Generic;

namespace CampusCRM.BLL.ModelsDTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Info { get; set; }

        public List<GroupDTO> Groups = new List<GroupDTO>();
    }
}
