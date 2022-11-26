using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIronGym.Models
{
    public class Relatorio
    {
        public List<Lancamento> Lancamentos { get; set; }
        public int UsuariosCadastrados { get; set; }//
        public int UsuariosInativos { get; set; }//
        public int CadastrosMes { get; set; }//
        public double AReceber { get; set; }//
        public double Total { get; set; }//
        public double TotalPlanos { get; set; }//
        public double TotalPersonal { get; set; }//
        public double TotalRecebimentos { get; set; }//
        public double TotalDespesas { get; set; }//
        public double TotalDescontos { get; set; }//

        public double BalancoMensal { get; set; }//
        public double BalancoTotal { get; set; }//
        public double CaixaAtual { get; set; }

    }

}
