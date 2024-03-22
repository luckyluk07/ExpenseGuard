using ExpenseGuardBackend.DTOs.InvestmentDeposits;

namespace ExpenseGuardBackend.Services.InvestmentDeposits
{
	public interface IInvestmentDepositService
	{
		InvestmentDepositDto? Get(int id);
		List<InvestmentDepositDto> GetAll();
		bool Remove(int id, int financeId);
	}
}