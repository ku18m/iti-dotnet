using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Courses.Models
{
    public class Course
    {
        [Key]
        public int CrsId { get; set; }

        [MaxLength(50)]
        public string CrsName { get; set; }

        public int? CrsDuration { get; set; }

        [ForeignKey("Topic")]
        public int TopId { get; set; }

        public virtual Topic Top { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
