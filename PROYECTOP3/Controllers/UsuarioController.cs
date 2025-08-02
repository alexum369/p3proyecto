using Microsoft.AspNetCore.Mvc;
using PROYECTOP3.Interfaces;
using PROYECTOP3.Models;

namespace PROYECTOP3.Controllers
{
    
    
        [ApiController]
        [Route("api/Users")]
        public class UsuariosController : ControllerBase
        {
            private readonly IUsuarioService _usuarioService;

            public UsuariosController(IUsuarioService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            [HttpGet]
            public IActionResult Get()
            {
                var usuarios = _usuarioService.ObtenerUsuarios();
                return Ok(usuarios);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var usuario = _usuarioService.ObtenerPorId(id);
                if (usuario == null) return NotFound();
                return Ok(usuario);
            }

            [HttpPost]
            public IActionResult Crear([FromBody] Usuario nuevoUsuario)
            {
                var usuarioCreado = _usuarioService.Crear(nuevoUsuario);
                return CreatedAtAction(nameof(GetById), new { id = usuarioCreado.Id }, usuarioCreado);
            }

            [HttpPut("{id}")]
            public IActionResult Actualizar(int id, [FromBody] Usuario usuarioActualizado)
            {
                var actualizado = _usuarioService.Actualizar(id, usuarioActualizado);
                if (actualizado == null) return NotFound();
                return Ok(actualizado);
            }

            [HttpDelete("{id}")]
            public IActionResult Eliminar(int id)
            {
                var eliminado = _usuarioService.Eliminar(id);
                if (!eliminado) return NotFound();
                return NoContent();
            }
        }
    }
