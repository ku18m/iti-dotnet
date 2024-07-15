using System.ComponentModel.DataAnnotations;

namespace ITI_Courses.Models
{
    public class Instructor
    {
        [Key]
        public int InsId { get; set; }

        [MaxLength(50)]
        public string? InsName { get; set; }

        [MaxLength(10), AllowedValues("PhD", "Master", "BSc")]
        public string? InsDegree { get; set; }

        public double Salary { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}
