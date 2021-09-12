using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.BLL.Enums;

namespace CampusCRM.BLL.ModelsDTO
{
    public class StudentRequestDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Comment { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }

        public int StudentId { get; set; }
        public StudentDTO Student { get; set; }

        public RequestStatus Status { get; set; }
    }
}
