



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
  [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private static List<Receta> recetas = new List<Receta>
        {
            new Receta { ID = Guid.NewGuid(), 
                    Nombre = "Tacos con frijoles",
                     Categoria = "Comida",
                      Imagen = "taco",
                      Instrucciones = "Poner frijoles en la tortilla ",
                       Tiempo = 5 
                    }
        };

        // GET: api/recetas
        [HttpGet]
        public ActionResult<IEnumerable<Receta>> GetRecetas()
        {
            return recetas;
        }

        // GET: api/recetas/505
        [HttpGet("{id}")]
        public ActionResult<Receta> GetReceta(Guid? id)
        {
            if(!id.HasValue){
                return NotFound();
            }
            var book = recetas.FirstOrDefault(b => b.ID == id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST: api/recetas
        [HttpPost]
        public ActionResult<Book> PostReceta(Receta receta)
        {
            recetas.Add(receta);
            return CreatedAtAction(nameof(GetReceta), new { id = receta.ID }, receta);
        }

        // PUT: api/recetas/505
        [HttpPut("{id}")]
        public IActionResult PutReceta(Guid id, Receta receta)
        {
            var existing = recetas.FirstOrDefault(b => b.ID == id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Nombre = receta.Nombre;
            existing.Categoria = receta.Categoria;
            existing.Imagen = receta.Imagen;
            existing.Instrucciones = receta.Instrucciones;
            existing.Tiempo = receta.Tiempo;

            return NoContent();
        }

        // DELETE: api/recetas/505
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var receta = recetas.FirstOrDefault(b => b.ID == id);
            if (receta == null)
            {
                return NotFound();
            }

            recetas.Remove(receta);
            return NoContent();
        }
    }

/*
    var id = UUID()
    var nombre: String
    var imagen: String
    var tiempo: Int
    var instrucciones: String
    var categoria: String
*/
    public class Receta
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int Tiempo { get; set; }
        public string Instrucciones { get; set; }
        public string Categoria { get; set; }
    }
}
