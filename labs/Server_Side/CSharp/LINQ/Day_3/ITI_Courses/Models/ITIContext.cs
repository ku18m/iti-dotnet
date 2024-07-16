using Microsoft.EntityFrameworkCore;

namespace ITI_Courses.Models
{
    public class ITIContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<InsCourse> InsCourses { get; set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITIDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");
        }
    }
}
