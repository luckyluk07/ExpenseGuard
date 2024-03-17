using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record FinanceDto
	(
		List<MoneyDto> CurrencySavings,
		List<IncomeDto> Incomes,
		List<ExpenseDto> Expenses
	);
}
