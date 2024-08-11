using Course_Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_Services.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController(ITIContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var courses = context.Courses.ToList();

            if (courses.Count == 0) return NotFound("No Courses Found");

            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            var course = context.Courses.Find(id);

            if (course == null) return NotFound("Course Not Found");

            return Ok(course);
        }

        [HttpGet("getbyname/{name:alpha}")]
        public ActionResult GetByName(string name)
        {
            var course = context.Courses.FirstOrDefault(c => c.Name == name);

            if (course == null) return NotFound("Course Not Found");

            return Ok(course);
        }

        [HttpPost]
        public ActionResult Post(Course course)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Courses.Add(course);

            context.SaveChanges();

            return CreatedAtAction("GetById", new { id = course.Id }, course);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Course course)
        {
            if (!ModelState.IsValid || id != course.Id) return BadRequest(ModelState);

            var courseToUpdate = context.Courses.Find(id);

            if (courseToUpdate == null) return NotFound("Course Not Found");

            context.Entry(courseToUpdate).CurrentValues.SetValues(course);

            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCourse(int id)
        {
            var course = context.Courses.Find(id);

            if (course == null) return NotFound("Course Not Found");

            context.Courses.Remove(course);

            context.SaveChanges();

            return Ok(context.Courses.ToList());
        }
    }
}
