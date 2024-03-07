namespace ExpenseGuardBackend.DTOs.Income
{
	public record UpdateIncomeDto
	(
		DateTime ReceivedDate,
		decimal Amount
	);
}
