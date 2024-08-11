using Microsoft.EntityFrameworkCore;

namespace Course_Services.Models
{
    public class ITIContext: DbContext
    {
        public ITIContext(DbContextOptions<ITIContext> options): base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# Course",
                    Duration = 40
                },
                new Course
                {
                    Id = 2,
                    Name = "Java",
                    Description = "Java Course",
                    Duration = 50
                },
                new Course
                {
                    Id = 3,
                    Name = "Python",
                    Description = "Python Course",
                    Duration = 60
                }
            );
        }
    }
}
