using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanaisVendaController : ControllerBase
    {
        private readonly ICanalVendaService _canalVendaService;

        public CanaisVendaController(ICanalVendaService canalVendaService)
        {
            _canalVendaService = canalVendaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCanalVendaList()
        {
            var canaisVenda = await _canalVendaService.GetAllCanaisVenda();
            if (canaisVenda == null)
            {
                return NotFound();
            }
            return Ok(canaisVenda);
        }
        [HttpGet("{codCV}")]
        public async Task<IActionResult> GetCanalVendaById(int codCV)
        {
            var canalVenda = await _canalVendaService.GetCanalVendaById(codCV);
            if (canalVenda == null)
            {
                return BadRequest();
            }
            return Ok(canalVenda);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCanalVenda([FromBody] CanalVenda detalhesCanalVenda)
        {
            var result = await _canalVendaService.CreateCanalVenda(detalhesCanalVenda);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCanalVenda([FromBody] CanalVenda detalhesCanalVenda)
        {
            var result = await _canalVendaService.UpdateCanalVenda(detalhesCanalVenda);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("{codCV}")]
        public async Task<IActionResult> DeleteCanalVenda(int codCV)
        {
            var (result, mensagem) = await _canalVendaService.DeleteCanalVenda(codCV);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(mensagem);
        }
    }
}
