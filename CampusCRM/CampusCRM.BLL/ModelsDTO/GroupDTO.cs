using System;
using System.Collections.Generic;

namespace CampusCRM.BLL.ModelsDTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
        public int TeacherId { get; set; }
        public TeacherDTO Teacher { get; set; }
      
    }
}
