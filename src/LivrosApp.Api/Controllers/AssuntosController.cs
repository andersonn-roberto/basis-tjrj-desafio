using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssuntosController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;
        public AssuntosController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAssuntoList()
        {
            var assuntos = await _assuntoService.GetAllAssuntos();
            if (assuntos == null)
            {
                return NotFound();
            }
            return Ok(assuntos);
        }
        [HttpGet("{codAs}")]
        public async Task<IActionResult> GetAssuntoById(int codAs)
        {
            var assunto = await _assuntoService.GetAssuntoById(codAs);
            if (assunto == null)
            {
                return BadRequest();
            }
            return Ok(assunto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAssunto([FromBody] Assunto detalhesAssunto)
        {
            var result = await _assuntoService.CreateAssunto(detalhesAssunto);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAssunto([FromBody] Assunto detalhesAssunto)
        {
            var result = await _assuntoService.UpdateAssunto(detalhesAssunto);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{codAs}")]
        public async Task<IActionResult> DeleteAssunto(int codAs)
        {
            var (result, mensagem) = await _assuntoService.DeleteAssunto(codAs);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(mensagem);
        }
    }
}
