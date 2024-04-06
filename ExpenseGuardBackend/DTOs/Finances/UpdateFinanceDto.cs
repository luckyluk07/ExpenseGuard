using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record UpdateFinanceDto
	(
		IEnumerable<IncomeDto> Incomes,
		IEnumerable<ExpenseDto> Expenses
	);
}
