using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.InvestmentDeposits
{
	public record CreateInvestmentDepositDto
	(
		string Name,
		DateTime StartDate,
		DateTime EndDate,
		CreateMoneyDto StartMoney,
		int YearCapitalizationAmount,
		decimal InterestRate,
		int FinanceId
	);
}
