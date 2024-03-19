namespace ExpenseGuardBackend.DTOs.Money
{
	public record CreateMoneyDto
	(
		decimal Amount,
		int CurrencyId
	);
}
