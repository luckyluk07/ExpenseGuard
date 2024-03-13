namespace ExpenseGuardBackend.DTOs.Expense
{
	public record UpdateExpenseDto
	(
		int CategoryId,
		decimal Price,
		int CurrencyId,
		DateTime SpendDate
	);
}
