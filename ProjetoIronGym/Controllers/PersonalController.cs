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
    public class PersonalController : ControllerBase
    {
        private PersonalService _personalService;

        public PersonalController(PersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpPost]
        public IActionResult AdicionaPersonal([FromBody] Personal personal)
        {
            _personalService.AdicionaPersonal(personal);
            return CreatedAtAction(nameof(RecuperaPersonaisPorId), new { Id = personal.Id }, personal);
        }


        [HttpGet]
        public IActionResult RecuperaPersonals()
        {
            List<Personal> personals = _personalService.RecuperaPersonais();
            if (personals == null) return NotFound();
            return Ok(personals);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPersonaisPorId(int id)
        {
            Personal personal = _personalService.RecuperaPersonaisPorId(id);
            if (personal == null) return NotFound();
            return Ok(personal);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPersonal(int id, [FromBody] UpdatePersonalDto updatePersonalDto)
        {
            Result resultado = _personalService.AtualizaPersonal(id, updatePersonalDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPersonal(int id)
        {
            Result resultado = _personalService.DeletaPersonal(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
