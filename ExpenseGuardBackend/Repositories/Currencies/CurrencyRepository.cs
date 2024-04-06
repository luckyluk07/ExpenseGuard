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

		public IEnumerable<Currency> Get()
		{
			return _expenseGuardDbContext.Currencies;
		}

		public Currency? Get(int id)
		{
			return _expenseGuardDbContext.Currencies
				.FirstOrDefault(x => x.Id == id);
		}
	}
}
