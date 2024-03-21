using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.InvestmentDeposits
{
	public interface IInvestmentDepositRepository
	{
		InvestmentDeposit Create(InvestmentDeposit investmentDeposit);
		InvestmentDeposit? Get(int id);
		List<InvestmentDeposit> GetAll();
		bool Remove(int id);
	}
}