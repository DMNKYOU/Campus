using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCRM.MVC.Configuration
{
    public class SecurityOptions
    {
        public const string SectionTitle = "Security";
        public string AdminUserEmail { get; set; }
        public string ManagerUserEmail { get; set; }

        public string Password { get; set; }
    }
}
