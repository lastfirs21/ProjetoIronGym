using AutoMapper;
using FluentResults;
using ProjetoIronGym.Data;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Data.Dtos.Create;
using ProjetoIronGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoIronGym.Services
{
    public class PagamentoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PagamentoService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void AdicionaPagamento(CreatePagamentoDto createPagamentoDto)
        {
            Pagamento pagamento = new Pagamento();
                _mapper.Map(createPagamentoDto, pagamento);

            pagamento.ValorTotal = CalculaTotal(pagamento);
            pagamento.DataDoPagamento = DateTime.Now;
            AtualizaProximoVencimento(pagamento.AlunoId, true);
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        private void AtualizaProximoVencimento(int alunoId, bool tipo) // atualizaProximoPagamento
        {
            Aluno aluno = _context.Alunos.Find(alunoId);

            if(aluno == null)
            {
            _context.SaveChanges();
            }
            else
            {

                if (tipo == true)
                {
                    aluno.VencimentoMensalidade = aluno.VencimentoMensalidade.AddMonths(aluno.Plano.MesesPlano);
                }
                else
                {
                    aluno.VencimentoMensalidade = aluno.VencimentoMensalidade.AddMonths(-(aluno.Plano.MesesPlano));
                }
            }
           
        }

        private double CalculaTotal(Pagamento pagamento)
        {
            return pagamento.ValorAdicionalPersonal - pagamento.Desconto + _context.Alunos.Find(pagamento.AlunoId).Plano.Valor;
        }


        public List<Pagamento> RecuperaPagamentos()
        {
            return _context.Pagamentos.OrderBy(a=>a.DataDoPagamento).ToList();
        }


        public List<Pagamento> RecuperaPagamentosPorNome(string nome)
        {
            List<Pagamento> pagamentos = RecuperaPagamentos().Where(t => t.Aluno.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
            if (pagamentos != null)
            {
                return pagamentos;
            }

            return null;

        }

        public Pagamento RecuperaPagamentosPorId(int id)
        {
            Pagamento pagamento = _context.Pagamentos.FirstOrDefault(t => t.Id == id);
            if (pagamento != null)
            {
                return pagamento;
            }

            return null;
        }

        public List<Pagamento> RecuperaPagamentosPorPeriodo(DateTime inicio, DateTime fim)
        {
            return RecuperaPagamentos()
                 .Where(t => inicio.Date <= t.DataDoPagamento.Date && t.DataDoPagamento.Date <= fim.Date).ToList();
        }

        public Result AtualizaPagamento(int id, UpdatePagamentoDto updatePagamentoDto)
        {
            Pagamento pagamento = _context.Pagamentos.FirstOrDefault(pagamento => pagamento.Id == id);
            if (pagamento == null)
            {
                return Result.Fail("Pagamento não encontrado");
            }
            updatePagamentoDto.ValorTotal = CalculaTotal(_mapper.Map(updatePagamentoDto, pagamento));
            _mapper.Map(updatePagamentoDto, pagamento);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaPagamento(int id)
        {
            Pagamento pagamento = _context.Pagamentos.FirstOrDefault(pagamento => pagamento.Id == id);
            if (pagamento == null)
            {
                return Result.Fail("Pagamento não encontrado");
            }

            AtualizaProximoVencimento(pagamento.AlunoId, false);
            _context.Remove(pagamento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
