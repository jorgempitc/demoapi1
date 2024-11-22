using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { ID = 404, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PurchaseTotal = 2300.50M, LoyaltyPoints = 450 }
        };

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return customers;
        }

        // GET: api/customers/404
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            customers.Add(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.ID }, customer);
        }

        // PUT: api/customers/404
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.ID == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PurchaseTotal = customer.PurchaseTotal;
            existingCustomer.LoyaltyPoints = customer.LoyaltyPoints;

            return NoContent();
        }

        // DELETE: api/customers/404
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            customers.Remove(customer);
            return NoContent();
        }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal PurchaseTotal { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
