using ITI_API.Models;

namespace ITI_API.DTOs
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
