using Microsoft.EntityFrameworkCore;
using NiboChallenge.Models;

namespace NiboChallenge.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=01;Persist Security Info=True;User ID=sa;Initial Catalog=ConciliationDB;Data Source=LAPTOP-Q906974O");
        }
    }
}