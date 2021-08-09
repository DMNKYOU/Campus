using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCRM.MVC.Models
{
    public class TeacherModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Name", Prompt = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Surname", Prompt = "Surname")]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"^(?:100|[2-9][0-9])$", ErrorMessage = "Your age should be 20-100")]
        public int Age { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Info", Prompt = "Some words about you")]
        public string Info { get; set; }

        public List<GroupModel> Groups = new List<GroupModel>();
    }
}
