using LivrosApp.Application.Inputs;
using LivrosApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLivroList()
        {
            var livros = await _livroService.GetAllLivros();
            if (livros == null)
            {
                return NotFound();
            }
            return Ok(livros);
        }
        [HttpGet("{codL}")]
        public async Task<IActionResult> GetLivroById(int codL)
        {
            var livro = await _livroService.GetLivroById(codL);
            if (livro == null)
            {
                return BadRequest();
            }
            return Ok(livro);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLivro([FromBody] LivroCreateModel detalhesLivro)
        {
            var result = await _livroService.CreateLivro(detalhesLivro);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLivro([FromBody] LivroUpdateModel detalhesLivro)
        {
            var result = await _livroService.UpdateLivro(detalhesLivro);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{codL}")]
        public async Task<IActionResult> DeleteLivro(int codL)
        {
            var result = await _livroService.DeleteLivro(codL);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
