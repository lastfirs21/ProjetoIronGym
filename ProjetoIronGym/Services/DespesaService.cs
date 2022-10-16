using AutoMapper;
using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIronGym.Services
{
    public class DespesaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public DespesaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AdicionaDespesa(Despesa despesa)
        {
            _context.Despesas.Add(despesa);
            _context.SaveChanges();
        }

        public List<Despesa> RecuperaDespesas()
        {
            return _context.Despesas.ToList();
        }

        public Despesa RecuperaDespesasPorId(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(t => t.Id == id);
            if (despesa != null)
            {
                return despesa;
            }

            return null;
        }

        public Result AtualizaDespesa(int id, UpdateDespesaDto updateDespesaDto)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa == null)
            {
                return Result.Fail("Despesa não encontrado");
            }
            _mapper.Map(updateDespesaDto, despesa);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaDespesa(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa == null)
            {
                return Result.Fail("Despesa não encontrado");
            }
            _context.Remove(despesa);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
