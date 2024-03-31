using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Currencies
{
	public class CurrencyRepository : ICurrencyRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public CurrencyRepository(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public List<Currency> Get()
		{
			return _expenseGuardDbContext.Currencies
				.ToList();
		}

		public Currency? Get(int id)
		{
			return _expenseGuardDbContext.Currencies
				.FirstOrDefault(x => x.Id == id);
		}
	}
}
