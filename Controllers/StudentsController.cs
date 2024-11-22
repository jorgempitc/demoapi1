using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { ID = 303, FirstName = "Maria", LastName = "Garcia", Major = "Computer Science", GPA = 3.8M, Credits = 120 }
        };

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return students;
        }

        // GET: api/students/303
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.ID }, student);
        }

        // PUT: api/students/303
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.ID == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Major = student.Major;
            existingStudent.GPA = student.GPA;
            existingStudent.Credits = student.Credits;

            return NoContent();
        }

        // DELETE: api/students/303
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            return NoContent();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public decimal GPA { get; set; }
        public int Credits { get; set; }
    }
}
