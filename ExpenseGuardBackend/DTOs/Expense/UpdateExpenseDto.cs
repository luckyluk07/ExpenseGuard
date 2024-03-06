namespace ExpenseGuardBackend.DTOs.Expense
{
	public record UpdateExpenseDto
	(
		string Category,
		decimal Price,
		DateTime SpendDate
	);
}
