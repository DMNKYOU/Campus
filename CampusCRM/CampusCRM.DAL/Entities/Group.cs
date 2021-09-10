using System;
using System.Collections.Generic;
using CampusCRM.DAL.Enums;

namespace CampusCRM.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public GroupStatus Status { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }    
        
        public List<Student> Students { get; set; } = new List<Student>();
        
    }
}
