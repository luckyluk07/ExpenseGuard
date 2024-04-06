using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record FinanceDto
	(
		int Id,
		IEnumerable<MoneyDto> CurrencySavings,
		IEnumerable<IncomeDto> Incomes,
		IEnumerable<ExpenseDto> Expenses,
		IEnumerable<InvestmentDepositDto> Investments
	);
}
