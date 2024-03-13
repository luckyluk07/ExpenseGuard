using ExpenseGuardBackend.DTOs.Currencies;

namespace ExpenseGuardBackend.DTOs.Money
{
	public record MoneyDto
	(
		decimal Amount,
		CurrencyDto Currency
	);
}
