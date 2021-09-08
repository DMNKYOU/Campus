using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CampusCRM.MVC.Models
{
    public class RoleManagerModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public RoleManagerModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
