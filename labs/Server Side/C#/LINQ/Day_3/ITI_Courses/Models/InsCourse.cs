using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Courses.Models
{
    [PrimaryKey("InsId", "CrsId")]
    public class InsCourse
    {
        [ForeignKey("Ins")]
        public int InsId { get; set; }

        [ForeignKey("Crs")]
        public int CrsId { get; set; }

        public string? Evaluation { get; set; }

        public virtual Course? Crs { get; set; }

        public virtual Instructor? Ins { get; set; }
    }
}
