using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Currencies
{
	public class CurrencyRepository : ICurrencyRepository
	{
		private List<Currency> _currencies;

		private int _lastAddedId = 0;

		public CurrencyRepository()
		{
			_currencies = new List<Currency>();
			var currency = new Currency
			{
				Name = "Polski zloty",
				Code = "PLN",
				Country = "Poland"
			};
			Create(currency);
			var currency2 = new Currency()
			{
				Name = "American Dollar",
				Code = "USD",
				Country = "USA"
			};
			Create(currency2);
		}

		private Currency Create(Currency currency)
		{
			currency.Id = _lastAddedId++;
			_currencies.Add(currency);
			return currency;
		}

		public List<Currency> Get()
		{
			return _currencies;
		}

		public Currency? Get(int id)
		{
			return _currencies.FirstOrDefault(x => x.Id == id);
		}
	}
}
