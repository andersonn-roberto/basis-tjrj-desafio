using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutorList()
        {
            var autores = await _autorService.GetAllAutores();
            if (autores == null)
            {
                return NotFound();
            }
            return Ok(autores);
        }

        [HttpGet("{codAu}")]
        public async Task<IActionResult> GetAutorById(int codAu)
        {
            var autor = await _autorService.GetAutorById(codAu);
            if (autor == null)
            {
                return BadRequest();
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor([FromBody] Autor detalhesAutor)
        {
            var result = await _autorService.CreateAutor(detalhesAutor);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutor([FromBody] Autor detalhesAutor)
        {
            var result = await _autorService.UpdateAutor(detalhesAutor);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{codAu}")]
        public async Task<IActionResult> DeleteAutor(int codAu)
        {
            var (result, mensagem) = await _autorService.DeleteAutor(codAu);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(mensagem);
        }
    }
}
