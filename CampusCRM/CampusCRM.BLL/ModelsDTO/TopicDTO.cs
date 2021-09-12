using System.Collections.Generic;

namespace CampusCRM.BLL.ModelsDTO
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}