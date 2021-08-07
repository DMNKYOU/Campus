using System.Collections.Generic;

namespace CampusCRM.DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }

        public List<Group> Groups = new List<Group>();
    }
}
