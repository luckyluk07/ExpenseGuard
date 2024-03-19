using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record UpdateFinanceDto
	(
		List<IncomeDto> Incomes,
		List<ExpenseDto> Expenses
	);
}
