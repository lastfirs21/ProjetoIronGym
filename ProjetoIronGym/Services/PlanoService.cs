using AutoMapper;
using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIronGym.Services
{
    public class PlanoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PlanoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AdicionaPlano(Plano plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();
        }

        public List<Plano> RecuperaPlanos()
        {
            return _context.Planos.ToList();
        }

        public Plano RecuperaPlanosPorId(int id)
        {
            Plano plano = _context.Planos.FirstOrDefault(t => t.Id == id);
            if (plano != null)
            {
                return plano;
            }

            return null;
        }

        public Result AtualizaPlano(int id, UpdatePlanoDto updatePlanoDto)
        {
            Plano plano = _context.Planos.FirstOrDefault(plano => plano.Id == id);
            if (plano == null)
            {
                return Result.Fail("Plano não encontrado");
            }
            _mapper.Map(updatePlanoDto, plano);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaPlano(int id)
        {
            Plano plano = _context.Planos.FirstOrDefault(plano => plano.Id == id);
            if (plano == null)
            {
                return Result.Fail("Plano não encontrado");
            }
            _context.Remove(plano);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
