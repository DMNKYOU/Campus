using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCRM.MVC.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Title", Prompt = "Title of topic")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Description", Prompt = "Description of topic")]
        public string Description { get; set; }

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
