using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_API.Models;
using ITI_API.DTOs;

namespace ITI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ITIContext _context;

        public StudentsController(ITIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// get all students
        /// </summary>
        /// <returns> list of students</returns>
        /// <remarks>
        /// request example:
        ///  /api/students/getall
        /// </remarks>
        [ProducesResponseType<List<StudentDTO>>(200)]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            var studentsDTO = new List<StudentDTO>();

            foreach (var student in students)
            {
                studentsDTO.Add(new StudentDTO
                {
                    id = student.StId,
                    fname = student.StFname,
                    lname = student.StLname,
                    address = student.StAddress,
                    age = student.StAge,
                    deptName = student.Dept?.DeptName ?? "No Department",
                    superName = student.StSuperNavigation?.StFname ?? "No Super"
                });
            }

            return Ok(studentsDTO);
        }

        /// <summary>
        /// Get students page.
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>The requested page</returns>
        /// <remarks>
        /// request example:
        ///  /api/students?pageSize=10&amp;pageNum=3
        /// </remarks>
        [ProducesResponseType<List<StudentDTO>>(200)]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpGet]
        public async Task<IActionResult> GetPage(int pageNum = 1, int pageSize=10)
        {
            var students = await _context.Students
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new StudentDTO()
                {
                    superName = s.StSuperNavigation.StFname,
                    deptName = s.Dept.DeptName,
                    age = s.StAge,
                    address = s.StAddress,
                    lname = s.StLname,
                    fname = s.StFname,
                    id = s.StId
                })
                .ToListAsync();

            if (students == null) return NotFound();
            
            return Ok(students);
        }

        /// <summary>
        /// Get students that contains the given name.
        /// </summary>
        /// <param name="name">Page number</param>
        /// <returns>List of matched Students</returns>
        /// <remarks>
        /// request example:
        ///  /api/students?stdName=Ali
        /// </remarks>
        [ProducesResponseType<List<StudentDTO>>(200)]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            var students = await _context.Students
                .Where(s => s.StFname.Contains(name) || s.StLname.Contains(name))
                .Select(s => new StudentDTO()
                {
                    superName = s.StSuperNavigation.StFname,
                    deptName = s.Dept.DeptName,
                    age = s.StAge,
                    address = s.StAddress,
                    lname = s.StLname,
                    fname = s.StFname,
                    id = s.StId
                })
                .ToListAsync();

            if (students == null) return NotFound();
            
            return Ok(students);
        }

        /// <summary>
        /// get student by student id
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns>A student with given id.</returns>
        /// <remarks>
        /// request example:
        ///  /api/students/3
        /// </remarks>
        [ProducesResponseType<StudentDTO>(200)]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = new StudentDTO()
            {
                id = student.StId,
                fname = student.StFname,
                lname = student.StLname,
                address = student.StAddress,
                age = student.StAge,
                deptName = student.Dept?.DeptName ?? "No Department",
                superName = student.StSuperNavigation?.StFname ?? "No Super"
            };

            return Ok(studentDTO);
        }

        /// <summary>
        /// Update student by student id with new data.
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns>No Content</returns>
        /// <remarks>
        /// request example:
        ///  /api/students/3
        /// </remarks>
        [ProducesResponseType(201, Type = typeof(void))]
        [ProducesResponseType(400, Type = typeof(void))]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDTO student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }

            var user = await _context.Students.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }


            user.StLname = student.lname;
            user.StFname = student.fname;
            user.StAddress = student.address;
            user.StAge = student.age;
            user.DeptId = _context.Departments
                .Where(d => d.DeptName == student.deptName)
                .Select(d => d.DeptId)
                .FirstOrDefault();

            user.StSuper = _context.Students
                .Where(s => s.StFname == student.fname)
                .Select(s => s.StId)
                .FirstOrDefault();
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Create new student with new data.
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns> New Student </returns>
        /// <remarks>
        /// request example:
        ///  /api/students/3
        /// </remarks>
        [ProducesResponseType<StudentDTO>(201)]
        [ProducesResponseType(400, Type = typeof(void))]
        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<Student>> PostStudent(StudentDTO student)
        {
            var stdId = _context.Students.Max(s => s.StId) + 1;
            var studentEntity = new Student
            {
                StId = stdId,
                StFname = student.fname,
                StLname = student.lname,
                StAddress = student.address,
                StAge = student.age,
                DeptId = _context.Departments
                    .Where(d => d.DeptName == student.deptName)
                    .Select(d => d.DeptId)
                    .FirstOrDefault(),
                StSuper = _context.Students
                    .Where(s => s.StFname == student.superName)
                    .Select(s => s.StId)
                    .FirstOrDefault()
            };

            _context.Students.Add(studentEntity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetStudent", new { id = studentEntity.StId }, student);
        }

        /// <summary>
        /// Delete student by student id
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns>A student with given id.</returns>
        /// <remarks>
        /// request example:
        ///  /api/students/3
        /// </remarks>
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> StudentExists(int id)
        {
            return _context.Students.Any(e => e.StId == id);
        }
    }
}
