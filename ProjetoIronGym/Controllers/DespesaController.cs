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
    public class DespesaController : ControllerBase
    {
        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpPost]
        public IActionResult AdicionaDespesa([FromBody] Despesa despesa)
        {
            _despesaService.AdicionaDespesa(despesa);
            return CreatedAtAction(nameof(RecuperaDespesasPorId), new { Id = despesa.Id }, despesa);
        }


        [HttpGet]
        public IActionResult RecuperaDespesas()
        {
            List<Despesa> despesas = _despesaService.RecuperaDespesas();
            if (despesas == null) return NotFound();
            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDespesasPorId(int id)
        {
            Despesa despesa = _despesaService.RecuperaDespesasPorId(id);
            if (despesa == null) return NotFound();
            return Ok(despesa);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto updateDespesaDto)
        {
            Result resultado = _despesaService.AtualizaDespesa(id, updateDespesaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDespesa(int id)
        {
            Result resultado = _despesaService.DeletaDespesa(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
    }
