using System;
using System.Collections.Generic;

namespace CampusCRM.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}
