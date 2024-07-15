using System.ComponentModel.DataAnnotations;

namespace ITI_Courses.Models
{
    public class Topic
    {
        [Key]
        public int TopId { get; set; }

        public string? TopName { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}
