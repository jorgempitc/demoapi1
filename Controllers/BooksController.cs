using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
  [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { ID = 505, Title = "Introduction to Programming", Author = "Alex Johnson", Genre = "Education", Price = 39.99M, Pages = 450 }
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return books;
        }

        // GET: api/books/505
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.ID }, book);
        }

        // PUT: api/books/505
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.ID == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Price = book.Price;
            existingBook.Pages = book.Pages;

            return NoContent();
        }

        // DELETE: api/books/505
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }

    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
    }
}
