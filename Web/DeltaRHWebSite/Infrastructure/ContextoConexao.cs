using DeltaRHWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltaRHWebSite.Infrastructure
{
    public class ContextoConexao : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=dbDeltaRH; User Id=admin; Password=admin; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
