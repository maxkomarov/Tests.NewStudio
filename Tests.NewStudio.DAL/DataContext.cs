using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.NewStudio.Models;

namespace Tests.NewStudio.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRateProvider> CurrencyRateProviders { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
