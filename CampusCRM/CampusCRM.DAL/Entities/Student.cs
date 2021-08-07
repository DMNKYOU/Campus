using System;
using System.Collections.Generic;
using System.Text;

namespace CampusCRM.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
