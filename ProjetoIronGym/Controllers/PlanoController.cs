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
    public class PlanoController : ControllerBase
    {
        private PlanoService _planoService;


        public PlanoController(PlanoService planoService)
        {
            _planoService = planoService;
        }

        [HttpPost]
        public IActionResult AdicionaPlano([FromBody] Plano plano)
        {
            _planoService.AdicionaPlano(plano);
            return CreatedAtAction(nameof(RecuperaPlanosPorId), new { Id = plano.Id }, plano);
        }


        [HttpGet]
        public IActionResult RecuperaPlanos()
        {
            List<Plano> planos = _planoService.RecuperaPlanos();
            if (planos == null) return NotFound();
            return Ok(planos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPlanosPorId(int id)
        {
            Plano plano = _planoService.RecuperaPlanosPorId(id);
            if (plano == null) return NotFound();
            return Ok(plano);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPlano(int id, [FromBody] UpdatePlanoDto updatePlanoDto)
        {
            Result resultado = _planoService.AtualizaPlano(id, updatePlanoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPlano(int id)
        {
            Result resultado = _planoService.DeletaPlano(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
