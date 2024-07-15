using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
