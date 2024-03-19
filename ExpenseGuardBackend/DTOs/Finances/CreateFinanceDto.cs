using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record CreateFinanceDto
	(
		List<CreateMoneyDto> CurrencySavings
	);
}
