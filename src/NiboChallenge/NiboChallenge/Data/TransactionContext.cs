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
    }
}
