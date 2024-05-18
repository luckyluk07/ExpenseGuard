using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.InvestmentDeposits
{
	public interface IInvestmentDepositRepository
	{
		InvestmentDeposit Create(InvestmentDeposit investmentDeposit);
		InvestmentDeposit? Get(int id);
		IEnumerable<InvestmentDeposit> GetAll();
		bool Remove(int id);
		InvestmentDeposit? Update(InvestmentDeposit investmentDepositToUpdate, int id);
	}
}