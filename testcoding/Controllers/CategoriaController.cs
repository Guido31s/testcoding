using Microsoft.AspNetCore.Mvc;
using testcoding.DTOs;
using testcoding.Models;

namespace testcoding.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var categorias = _categoriaService.GetAllCategorias();
            var categoriaListDtos = categorias.Select(categoria => new ListCategoriaDTO
            {
                Nombre = categoria.Nombre
            });
            return Ok(categoriaListDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoria(int id)
        {
            var categoria = _categoriaService.GetCategoriaById(id);
            if (categoria == null)
            {
                return NotFound($"Categoría con ID {id} no encontrada.");
            }
            var categoriaDto = new CategoriaDTO
            {
                CategoriaId = categoria.CategoriaId,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };
            return Ok(categoriaDto);
        }

        [HttpPost]
        public IActionResult CreateCategoria([FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
            {
                return BadRequest("Los datos de la categoría son nulos.");
            }

            // Mapea el DTO a una entidad de Categoría si es necesario
            var categoria = new Categorium
            {
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion
            };

            _categoriaService.AddCategoria(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoriaDto);
        }

        [HttpPut("{id}")]
        public IActionResult EditCategoria(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null)
            {
                return BadRequest("Los datos de la categoría son nulos.");
            }

            var categoria = new Categorium
            {
                CategoriaId = id,
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion
            };

            if (!_categoriaService.UpdateCategoria(categoria))
            {
                return NotFound($"Categoría con ID {id} no encontrada.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            if (!_categoriaService.DeleteCategoria(id))
            {
                return NotFound($"Categoría con ID {id} no encontrada.");
            }
            return Ok();
        }
    }
}
