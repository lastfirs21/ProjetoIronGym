using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoIronGym.Data;
using ProjetoIronGym.Services;
using System;

namespace ProjetoIronGym
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(opts =>
                opts.UseLazyLoadingProxies()
                .UseSqlite(Configuration.GetConnectionString("AcademiaConnection")));

                services.AddCors(); // LIBERA O ACESSO POR OUTRAS APIS
                services.AddControllers();
                services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                services.AddScoped<AlunoService, AlunoService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<PagamentoService, PagamentoService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<PersonalService, PersonalService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<PlanoService, PlanoService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<DespesaService, DespesaService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<RecebimentoService, RecebimentoService>();// Para Adicionar uma Serice ao Escopo
                services.AddScoped<RelatorioService, RelatorioService>();// Para Adicionar uma Serice ao Escopo
      

            services.AddControllers();
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // LIBERA O ACESSO POR OUTRAS APIS
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
