using AutoMapper;
using ProjetoIronGym.Data;
using ProjetoIronGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIronGym.Services
{
    public class RelatorioService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private AlunoService _alunoService;
        private PagamentoService _pagamentoService;
        private DespesaService _despesaService;
        private RecebimentoService _recebimentoService;


        public RelatorioService(AppDbContext context, AlunoService alunoService, PagamentoService pagamentoService,
            DespesaService despesaService, RecebimentoService recebimentoService, IMapper mapper)
        {
            _mapper = mapper;
            _alunoService = alunoService;
            _pagamentoService = pagamentoService;
            _despesaService = despesaService;
            _recebimentoService = recebimentoService;
            _context = context;
        }



        public Relatorio RecuperaRelatorio(DateTime dataInicio, DateTime dataFim)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Lancamentos = new List<Lancamento>();
            List<Pagamento> pagamentosPeriodo = _pagamentoService.RecuperaPagamentosPorPeriodo(dataInicio, dataFim);
            List<Despesa> despesasPeriodo = _despesaService.RecuperaDespesasPorPeriodo(dataInicio, dataFim);
            List<Recebimento> recebimentosPeriodo = _recebimentoService.RecuperaRecebimentosPorPeriodo(dataInicio, dataFim);
            List<Aluno> alunosVencido = _alunoService.RecuperaAlunos().Where(t => t.Status != "Inativo" && t.StatusMensalidade == "Vencido").ToList();


            alunosVencido.ForEach((t) =>
            {
                relatorio.AReceber += t.Plano.Valor;
            });

            pagamentosPeriodo.ForEach(p =>
            {
                relatorio.TotalPlanos += p.ValorPlano - p.Desconto;
                relatorio.TotalPersonal += p.ValorAdicionalPersonal;
                relatorio.TotalDescontos += p.Desconto;
                relatorio.Total += p.ValorTotal;
                relatorio.Lancamentos.Add(_mapper.Map<Lancamento>(p));
            });

            despesasPeriodo.ForEach(d =>
            {
                relatorio.TotalDespesas += d.Valor;
                relatorio.Lancamentos.Add(_mapper.Map<Lancamento>(d));
            });

            recebimentosPeriodo.ForEach(r =>
            {
                relatorio.TotalRecebimentos += r.Valor;
                relatorio.Total += r.Valor;
                relatorio.Lancamentos.Add(_mapper.Map<Lancamento>(r));
            });

            relatorio.UsuariosCadastrados = _context.Alunos.Count(); // total de cadastros

            relatorio.CadastrosMes = _context.Alunos
                .Where(t => t.DataCadastro.Year == DateTime.Now.Year && t.DataCadastro.Month == DateTime.Now.Month).Count(); // cadastros mes

            relatorio.UsuariosInativos = _alunoService.RecuperaAlunos().Where(t => t.Status == "Inativo").Count();


            relatorio.BalancoMensal = relatorio.Total - relatorio.TotalDespesas;


            relatorio.Lancamentos = relatorio.Lancamentos.OrderBy(t => t.DataDoPagamento).ToList();

            _context.Pagamentos.ToList().ForEach(p => relatorio.CaixaAtual += p.ValorTotal);

            _context.Despesas.ToList().ForEach(p => relatorio.CaixaAtual -= p.Valor);

            _context.Recebimentos.ToList().ForEach(p => relatorio.CaixaAtual += p.Valor);

            relatorio.BalancoTotal = relatorio.Total + relatorio.AReceber - relatorio.TotalDespesas + relatorio.CaixaAtual;

            return (relatorio);
        }
    }
}
