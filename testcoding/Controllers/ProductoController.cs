using Microsoft.AspNetCore.Mvc;
using testcoding.DTOs;
using testcoding.Models;

namespace testcoding.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var productos = _productoService.GetAllProductos();
            var productoDtos = productos.Select(producto => new ListProductoDTO
            {

                Nombre = producto.Nombre,

            });
            return Ok(productoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound($"Producto con ID {id} no encontrado.");
            }
            var productoDto = new ProductoDTO
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                CantMin = producto.CantMin,
                CantMax = producto.CantMax,
                CantTotal = producto.CantTotal,
                CategoriaId = producto.CategoriaId
            };
            return Ok(productoDto);
        }

        [HttpPost]
        public IActionResult CreateProducto([FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest("Los datos del producto son nulos.");
            }

            // Mapea el DTO a una entidad de Producto si es necesario
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                CantMin = productoDto.CantMin,
                CantMax = productoDto.CantMax,
                CantTotal = productoDto.CantTotal,
                CategoriaId = productoDto.CategoriaId
            };

            _productoService.AddProducto(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, productoDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditProducto(int id, [FromBody] ProductoDTO productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest("Los datos del producto son nulos.");
            }

            var producto = _productoService.GetProductoById(id);

            if (producto == null)
            {
                return NotFound($"Producto con ID {id} no encontrado.");
            }

            // Actualiza las propiedades del producto con los valores del DTO
            producto.Nombre = productoDto.Nombre;
            producto.Descripcion = productoDto.Descripcion;
            producto.CantMin = productoDto.CantMin;
            producto.CantMax = productoDto.CantMax;
            producto.CantTotal = productoDto.CantTotal;
            producto.CategoriaId = productoDto.CategoriaId;

            if (!_productoService.UpdateProducto(producto))
            {
                return StatusCode(500, "Ocurrió un error al actualizar el producto.");
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            if (!_productoService.DeleteProducto(id))
            {
                return NotFound($"Producto con ID {id} no encontrado.");
            }
            return Ok();
        }
    }
}
