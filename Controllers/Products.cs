using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoapis.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productsontroller : ControllerBase
    {
    

    private static List<Product> products = new List<Product>
        {
            new Product { ID = 101, Name = "Laptop", Description = "A high-performance laptop", Category = "Electronics", Price = 1500.99M, Quantity = 50 }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return products;
        }

        // GET: api/products/101
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        // PUT: api/products/101
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ID == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            return NoContent();
        }

        // DELETE: api/products/101
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return NoContent();
        }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
