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
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Info { get; set; }

        public List<GroupModel> Groups = new List<GroupModel>();
    }
}
