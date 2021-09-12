using System;
using System.Collections.Generic;
using CampusCRM.BLL.Enums;

namespace CampusCRM.BLL.ModelsDTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public GroupStatus Status { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }

        public int? TeacherId { get; set; }
        public TeacherDTO Teacher { get; set; }    
        
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
        
    }
}
