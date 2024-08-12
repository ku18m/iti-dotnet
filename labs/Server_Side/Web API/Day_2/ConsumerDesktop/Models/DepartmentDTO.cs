using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktop.Models
{
    public class DepartmentDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string location { get; set; }

        public int? managerId { get; set; }

        public DateOnly? managerHiredate { get; set; }

        public int Students { get; set; }
    }
}
