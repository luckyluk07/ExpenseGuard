using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Currencies;

namespace ExpenseGuardBackend.Services.Currencies
{
	public class CurrencyService : ICurrencyService
	{
		private readonly ICurrencyRepository _currencyRepository;

		public CurrencyService(ICurrencyRepository currencyRepository)
		{
			_currencyRepository = currencyRepository;
		}

		public List<CurrencyDto> GetCurrencies()
		{
			return _currencyRepository.Get()
				.Select(MapCurrencyToDto)
				.ToList();
		}

		public CurrencyDto? GetCurrency(int id)
		{
			var currency = _currencyRepository.Get(id);
			if (currency is null)
			{
				return null;
			}
			return MapCurrencyToDto(currency);
		}

		private CurrencyDto MapCurrencyToDto(Currency currency)
		{
			return new CurrencyDto(currency.Id, currency.Name, currency.Code, currency.Country);
		}
	}
}
