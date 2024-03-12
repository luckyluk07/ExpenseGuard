using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Currencies
{
	public interface ICurrencyRepository
	{
		List<Currency> Get();
		Currency? Get(int id);
	}
}