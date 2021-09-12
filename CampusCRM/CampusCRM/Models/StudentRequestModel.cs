using System;
using System.ComponentModel.DataAnnotations;

namespace CampusCRM.MVC.Models
{
    public class StudentRequestModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date to start")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Comment")] 
        public string Comments { get; set; }

        [Required] 
        [Display(Name = "Course")] 
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        [Required] 
        [Display(Name = "Student")] 
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }

        public string Status { get; set; }
    }
}