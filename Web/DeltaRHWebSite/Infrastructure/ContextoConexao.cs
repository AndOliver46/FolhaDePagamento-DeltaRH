using DeltaRH.API.Models;
using DeltaRHWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltaRHWebSite.Infrastructure
{
    public class ContextoConexao : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<MissaoVisaoValores> MissaoVisaoValores { get; set; }
        public DbSet<NormaRegra> NormaRegra { get; set; }
        public DbSet<PoliticaDisciplinar> PoliticaDisciplinar { get; set; }
        public DbSet<Holerite> Holerites { get; set; }
        public DbSet<PontoEletronico> PontosEletronicos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
