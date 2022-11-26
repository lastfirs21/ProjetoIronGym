using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using ProjetoIronGym.Services;
using System;
using System.Collections.Generic;

namespace ProjetoIronGym.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private RelatorioService _relatorioService;

        public RelatorioController(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }


        [HttpPost]
        public IActionResult Relatorio([FromBody] DateTime[] datas)
        {
            Relatorio relatorio = _relatorioService.RecuperaRelatorio((DateTime) datas.GetValue(0), (DateTime) datas.GetValue(1));
            if (relatorio == null) return NotFound();
            return Ok(relatorio);
        }

    }
}
