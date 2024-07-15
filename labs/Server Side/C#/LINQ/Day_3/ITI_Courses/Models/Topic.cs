using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
