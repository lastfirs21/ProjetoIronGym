using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ProjetoIronGym.Services
{
    public class AlunoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AlunoService( AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void AdicionaAluno(Aluno aluno)
        {

            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public List<Aluno> RecuperaAlunos()
        {
            List<Aluno> alunos = _context.Alunos.ToList();

            alunos.ForEach((Aluno aluno) =>
            {
                if(DateTime.Now.Subtract(aluno.VencimentoMensalidade).TotalDays >10)
                {
                    aluno.Status = "Inativo";
                }
                else
                {
                    aluno.Status = "Ativo";
                }



                if(DateTime.Now.Subtract(aluno.VencimentoMensalidade).TotalDays >= 1)
                {
                    aluno.StatusMensalidade = "Vencido";
                }
                else
                {
                    aluno.StatusMensalidade = "Em Dia";
                }
                
            });
            _context.SaveChanges();
                return _context.Alunos.OrderBy(a=>a.Nome).ToList();
        }

        public List<Aluno> RecuperaAlunosPorNome(string nome)
        {
            List<Aluno> alunos = RecuperaAlunos().Where(t => t.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
            if (alunos != null)
            {
                return alunos;
            }

            return null;

        }

        public Aluno RecuperaAlunosPorId(int id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(t => t.Id == id);
            if (aluno != null)
            {
                return aluno;
            }

            return null;
        }

        public Result AtualizaAluno(int id, UpdateAlunoDto updateAlunoDto)
        {
            Aluno aluno = _context.Alunos.First(t=>t.Id == id);
            if (aluno == null)
            {
                return Result.Fail("Aluno não encontrado");
            }
            _mapper.Map(updateAlunoDto, aluno);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaAluno(int id)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null)
            {
                return Result.Fail("Aluno não encontrado");
            }
            _context.Remove(aluno);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
