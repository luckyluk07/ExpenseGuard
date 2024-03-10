namespace ExpenseGuardBackend.DTOs.Expense
{
	public record UpdateExpenseDto
	(
		int CategoryId,
		decimal Price,
		DateTime SpendDate
	);
}
