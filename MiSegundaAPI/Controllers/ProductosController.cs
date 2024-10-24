using Microsoft.AspNetCore.Mvc;
using MiSegundaAPI.Models;


namespace MiSegundaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1500 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25 }
        };

        // GET: api/Productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return Ok(productos);
        }

        // GET: api/Productos/1
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {

            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)

            {
                return NotFound();
            }

            return Ok(producto);
        }
        // POST: api/Productos
        [HttpPost]
        public ActionResult<Producto> CrearProducto(Producto nuevoProducto)
        {
            nuevoProducto.Id = productos.Max(p => p.Id) + 1;
            productos.Add(nuevoProducto);
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id }, nuevoProducto);
        }
        // PUT: api/Productos/1
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarProductos(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            productos.Remove(producto);
            return NoContent();
        }

    }
}
