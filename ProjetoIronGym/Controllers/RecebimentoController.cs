using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using ProjetoIronGym.Services;
using System.Collections.Generic;

namespace ProjetoIronGym.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecebimentoController : ControllerBase
    {
        private RecebimentoService _recebimentoService;

        public RecebimentoController(RecebimentoService recebimentoService)
        {
            _recebimentoService = recebimentoService;
        }

        [HttpPost]
        public IActionResult AdicionaRecebimento([FromBody] Recebimento recebimento)
        {
            _recebimentoService.AdicionaRecebimento(recebimento);
            return CreatedAtAction(nameof(RecuperaRecebimentosPorId), new { Id = recebimento.Id }, recebimento);
        }


        [HttpGet]
        public IActionResult RecuperaRecebimentos()
        {
            List<Recebimento> recebimentos = _recebimentoService.RecuperaRecebimentos();
            if (recebimentos == null) return NotFound();
            return Ok(recebimentos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaRecebimentosPorId(int id)
        {
            Recebimento recebimento = _recebimentoService.RecuperaRecebimentosPorId(id);
            if (recebimento == null) return NotFound();
            return Ok(recebimento);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaRecebimento(int id, [FromBody] UpdateRecebimentoDto updateRecebimentoDto)
        {
            Result resultado = _recebimentoService.AtualizaRecebimento(id, updateRecebimentoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaRecebimento(int id)
        {
            Result resultado = _recebimentoService.DeletaRecebimento(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
