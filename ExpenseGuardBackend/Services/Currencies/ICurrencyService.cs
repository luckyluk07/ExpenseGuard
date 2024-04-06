using ExpenseGuardBackend.DTOs.Currencies;

namespace ExpenseGuardBackend.Services.Currencies
{
	public interface ICurrencyService
	{
		IEnumerable<CurrencyDto> GetCurrencies();
		CurrencyDto? GetCurrency(int id);
	}
}