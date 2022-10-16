using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Data.Dtos.Create;
using ProjetoIronGym.Models;
using ProjetoIronGym.Services;
using System.Collections.Generic;

namespace ProjetoIronGym.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private PagamentoService _pagamentoService;

        public PagamentoController(PagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public IActionResult AdicionaPagamento([FromBody] CreatePagamentoDto createPagamentoDto)
        {
            _pagamentoService.AdicionaPagamento(createPagamentoDto);
            return Ok();
        }


        [HttpGet]
        public IActionResult RecuperaPagamentos()
        {
            List<Pagamento> pagamentos = _pagamentoService.RecuperaPagamentos();
            if (pagamentos == null) return NotFound();
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPagamentosPorId(int id)
        {
            Pagamento pagamento = _pagamentoService.RecuperaPagamentosPorId(id);
            if (pagamento == null) return NotFound();
            return Ok(pagamento);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPagamento(int id, [FromBody] UpdatePagamentoDto updatePagamentoDto)
        {
            Result resultado = _pagamentoService.AtualizaPagamento(id, updatePagamentoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPagamento(int id)
        {
            Result resultado = _pagamentoService.DeletaPagamento(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}