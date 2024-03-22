using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.InvestmentDeposits
{
	public record InvestmentDepositDto
	(
		int Id,
		string Name,
		DateTime StartDate,
		DateTime EndDate,
		MoneyDto StartMoney,
		int YearCapitalizationAmount,
		decimal InterestRate
	);
}
