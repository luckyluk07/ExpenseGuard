using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public interface IFinanceRepository
	{
		Finance Create(Finance newFinance);
		Finance? Get(int id);
		List<Finance> GetAll();
		bool Remove(int id);
		bool RemoveInvestmentDeposit(int investmentId, int financeId);
		Finance? Update(Finance updateData, int id);
		bool AddInvestmentDeposit(InvestmentDeposit investmentDeposit, int financeId);
	}
}