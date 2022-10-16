using Microsoft.EntityFrameworkCore;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Aluno>()
               .HasOne(aluno => aluno.Personal)
               .WithMany(personal => personal.Alunos)
               .HasForeignKey(aluno => aluno.PersonalId)
                .OnDelete(DeleteBehavior.Restrict);




            builder.Entity<Aluno>()
               .HasOne(aluno => aluno.Plano)
               .WithMany(plano => plano.Alunos)
               .HasForeignKey(aluno => aluno.PlanoId)
               .OnDelete(DeleteBehavior.Restrict);




            builder.Entity<Pagamento>()
               .HasOne(pagamento => pagamento.Aluno)
               .WithMany(aluno => aluno.Pagamentos)
               .HasForeignKey(pagamento => pagamento.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);



        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Personal> Personais { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
    }
}
