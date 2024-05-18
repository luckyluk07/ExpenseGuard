using ExpenseGuardBackend.DTOs.Money;

namespace ExpenseGuardBackend.DTOs.InvestmentDeposits
{
	public record UpdateInvestmentDepositDto
	(
		// todo fix update indestment bad request
		string Name,
		DateTime StartDate,
		DateTime EndDate,
		MoneyDto StartMoney,
		int YearCapitalizationAmount,
		decimal InterestRate
	);
}
