using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record CreateFinanceDto
	(
		IEnumerable<CreateMoneyDto> CurrencySavings
	);
}
