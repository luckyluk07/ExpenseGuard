namespace ExpenseGuardBackend.DTOs.Income
{
	public record IncomeDto
	(
		int Id,
		string Name,
		DateTime ReceivedDate,
		decimal Amount
	);
}
