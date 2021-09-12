using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CampusCRM.MVC.Validation;


namespace CampusCRM.MVC.Models
{
    public class GroupModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Name", Prompt = "Name")] 
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DateNotInThePast(ErrorMessage = "The date must be greater than the current one and no more than 2 years in advance")]
        public DateTime StartDate { get; set; }

        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
        
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        public TeacherModel Teacher { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int? Status { get; set; }

    }
}
