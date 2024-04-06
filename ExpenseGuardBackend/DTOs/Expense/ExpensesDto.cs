namespace ExpenseGuardBackend.DTOs.Expense
{
	public record ExpensesDto
	(
		IEnumerable<ExpenseDto> Expenses
	);
}
