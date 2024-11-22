using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
  [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 202, FirstName = "John", LastName = "Doe", Position = "Software Engineer", Salary = 85000, YearsOfExperience = 5 }
        };

        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return employees;
        }

        // GET: api/employees/202
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee);
        }

        // PUT: api/employees/202
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.ID == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.YearsOfExperience = employee.YearsOfExperience;

            return NoContent();
        }

        // DELETE: api/employees/202
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);
            return NoContent();
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
