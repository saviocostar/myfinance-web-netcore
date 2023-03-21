using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=CPU-00480\SQLEXPRESS;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}