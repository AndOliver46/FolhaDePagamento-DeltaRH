﻿using DeltaRHWebSite.Models;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=BD_DELTA; User Id=admin; Password=admin; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}