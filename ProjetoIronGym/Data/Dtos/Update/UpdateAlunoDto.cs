using System;

namespace ProjetoIronGym.Data.Dtos.Update
{
    public class UpdateAlunoDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Status { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime VencimentoMensalidade { get; set; }
        public string StatusMensalidade { get; set; }
        public int PlanoId { get; set; }
        public int PersonalId { get; set; }
    }
}
