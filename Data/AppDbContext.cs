using Depi_Assigment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Depi_Assigment.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("Bank");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
