using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Currencies
{
	public interface ICurrencyRepository
	{
		IEnumerable<Currency> Get();
		Currency? Get(int id);
	}
}