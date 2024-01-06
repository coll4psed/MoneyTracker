using Microsoft.EntityFrameworkCore;
using MoneyTrackerAPI.Models;

namespace MoneyTrackerAPI.Contexts
{
    public class MoneyTrackerContext : DbContext
    {
        public MoneyTrackerContext(DbContextOptions<MoneyTrackerContext> options) : base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
