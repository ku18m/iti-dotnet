using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Services.Models
{
    public class Course
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        public int Duration { get; set; }
    }
}
