using System;
using System.Collections.Generic;
using System.Text;
using CampusCRM.DAL.Enums;

namespace CampusCRM.DAL.Entities
{
    public class StudentRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Comment { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public RequestStatus Status { get; set; }
    }
}
