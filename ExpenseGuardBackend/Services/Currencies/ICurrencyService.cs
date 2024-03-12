﻿using ExpenseGuardBackend.DTOs.Currencies;

namespace ExpenseGuardBackend.Services.Currencies
{
	public interface ICurrencyService
	{
		List<CurrencyDto> GetCurrencies();
		CurrencyDto? GetCurrency(int id);
	}
}