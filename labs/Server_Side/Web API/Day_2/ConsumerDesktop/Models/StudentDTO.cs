using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktop.Models
{
    public class StudentDTO
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public int? age { get; set; }
        public string? deptName { get; set; }
        public string? superName { get; set; }
    }
}
