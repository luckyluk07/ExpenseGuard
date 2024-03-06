namespace ExpenseGuardBackend.DTOs.Expense
{
	public record ExpenseDto
	(
		int Id,
		string Name,
		string Category,
		decimal Price,
		DateTime SpendDate
	);
}
