using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore
{
    public class MyFinanceDbContextj : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<PlanoConta> Transacao { get; set; }

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "";
        optionsBuilder.UseSqlServer(connectionString);
    }
}