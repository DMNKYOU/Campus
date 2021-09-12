using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusCRM.MVC.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name="Topic")]
        public int TopicId { get; set; }
        public TopicModel Topic { get; set; }

        public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
    }
}
