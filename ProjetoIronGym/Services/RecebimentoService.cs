using AutoMapper;
using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIronGym.Services
{
    public class RecebimentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RecebimentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AdicionaRecebimento(Recebimento recebimento)
        {
            _context.Recebimentos.Add(recebimento);
            _context.SaveChanges();
        }

        public List<Recebimento> RecuperaRecebimentos()
        {
            return _context.Recebimentos.ToList();
        }

        public Recebimento RecuperaRecebimentosPorId(int id)
        {
            Recebimento recebimento = _context.Recebimentos.FirstOrDefault(t => t.Id == id);
            if (recebimento != null)
            {
                return recebimento;
            }

            return null;
        }

        public List<Recebimento> RecuperaRecebimentosPorPeriodo(DateTime inicio, DateTime fim)
        {
            return RecuperaRecebimentos()
                 .Where(t => inicio.Date <= t.DataDoPagamento.Date && t.DataDoPagamento.Date <= fim.Date).ToList();
        }
        public Result AtualizaRecebimento(int id, UpdateRecebimentoDto updateRecebimentoDto)
        {
            Recebimento recebimento = _context.Recebimentos.FirstOrDefault(recebimento => recebimento.Id == id);
            if (recebimento == null)
            {
                return Result.Fail("Recebimento não encontrado");
            }
            _mapper.Map(updateRecebimentoDto, recebimento);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaRecebimento(int id)
        {
            Recebimento recebimento = _context.Recebimentos.FirstOrDefault(recebimento => recebimento.Id == id);
            if (recebimento == null)
            {
                return Result.Fail("Recebimento não encontrado");
            }
            _context.Remove(recebimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
