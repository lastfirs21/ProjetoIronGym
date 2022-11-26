using AutoMapper;
using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIronGym.Services
{
    public class PersonalService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PersonalService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AdicionaPersonal(Personal personal)
        {
            _context.Personais.Add(personal);
            _context.SaveChanges();
        }

        public List<Personal> RecuperaPersonais()
        {
            return _context.Personais.OrderBy(a=>a.Nome).ToList();
        }

        public Personal RecuperaPersonaisPorId(int id)
        {
            Personal personal = _context.Personais.FirstOrDefault(t => t.Id == id);
            if (personal != null)
            {
                return personal;
            }

            return null;
        }

        public Result AtualizaPersonal(int id, UpdatePersonalDto updatePersonalDto)
        {
            Personal personal = _context.Personais.FirstOrDefault(personal => personal.Id == id);
            if (personal == null)
            {
                return Result.Fail("Personal não encontrado");
            }
            _mapper.Map(updatePersonalDto, personal);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaPersonal(int id)
        {
            Personal personal = _context.Personais.FirstOrDefault(personal => personal.Id == id);
            if (personal == null)
            {
                return Result.Fail("Personal não encontrado");
            }
            _context.Remove(personal);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
