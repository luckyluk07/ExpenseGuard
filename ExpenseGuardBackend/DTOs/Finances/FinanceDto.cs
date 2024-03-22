using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.Finances
{
	public record FinanceDto
	(
		int Id,
		List<MoneyDto> CurrencySavings,
		List<IncomeDto> Incomes,
		List<ExpenseDto> Expenses,
		List<InvestmentDepositDto> Investments
	);
}
