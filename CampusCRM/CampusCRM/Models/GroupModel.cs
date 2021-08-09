using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        public DateTime StartDate { get; set; }

        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
        
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        public TeacherModel Teacher { get; set; }

    }
}
