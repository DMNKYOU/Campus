using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.BLL.Enums;

namespace CampusCRM.BLL.ModelsDTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int? GroupId { get; set; }
        public GroupDTO Group { get; set; }
    }
}
