using ExpenseGuardBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseGuardBackend.Repositories
{
    public class ExpenseGuardDbContext : DbContext
    {
		public ExpenseGuardDbContext(DbContextOptions<ExpenseGuardDbContext> options): base(options)
		{
		}

		public DbSet<Finance> Finances { get; set; }
        public DbSet<InvestmentDeposit> InvestmentsDeposits { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Money> Money { get; set; }
    }
}
