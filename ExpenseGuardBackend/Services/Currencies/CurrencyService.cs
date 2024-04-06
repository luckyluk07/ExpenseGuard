using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Mappers;

namespace ExpenseGuardBackend.Services.Currencies
{
	public class CurrencyService : ICurrencyService
	{
		private readonly ICurrencyRepository _currencyRepository;

		public CurrencyService(ICurrencyRepository currencyRepository)
		{
			_currencyRepository = currencyRepository;
		}

		public IEnumerable<CurrencyDto> GetCurrencies()
		{
			return _currencyRepository.Get()
				.Select(DtoMapper.CurrencyToDto);
		}

		public CurrencyDto? GetCurrency(int id)
		{
			var currency = _currencyRepository.Get(id);
			if (currency is null)
			{
				return null;
			}
			return DtoMapper.CurrencyToDto(currency);
		}
	}
}
