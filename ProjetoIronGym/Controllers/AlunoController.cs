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
    public class AlunoController : ControllerBase
    {
        private AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public IActionResult AdicionaAluno([FromBody] Aluno aluno)
        {
            _alunoService.AdicionaAluno(aluno);
            return CreatedAtAction(nameof(RecuperaAlunosPorId), new { Id = aluno.Id }, aluno);
        }


 
        [HttpGet]
        public IActionResult RecuperaAlunos(string nome)
        {
            List<Aluno> alunos;

            if (nome == "undefined") nome = null;

            if(nome != null)
            {
            alunos = _alunoService.RecuperaAlunosPorNome(nome);
            }
            else
            {
                alunos = _alunoService.RecuperaAlunos();
            }
            if (alunos == null) return NotFound();
            return Ok(alunos);
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaAlunosPorId(int id)
        {
            Aluno aluno = _alunoService.RecuperaAlunosPorId(id);
            if (aluno == null) return NotFound();
            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAluno(int id, [FromBody] UpdateAlunoDto updateAlunoDto)
        {
            Result resultado = _alunoService.AtualizaAluno(id, updateAlunoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAluno(int id)
        {
            Result resultado = _alunoService.DeletaAluno(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }


    }
}
