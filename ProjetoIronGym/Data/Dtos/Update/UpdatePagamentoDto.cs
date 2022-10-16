namespace ProjetoIronGym.Data.Dtos.Update
{
    public class UpdatePagamentoDto
    {
        public int AlunoId { get; set; }
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public double ValorAdicionalPersonal { get; set; }
        public double ValorPlano { get; set; }

        public string FormaPagamento { get; set; }

        public string Observacoes { get; set; }

    }
}
