using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public interface IFinanceRepository
	{
		Finance Create(Finance newFinance);
		Finance? Get(int id);
		IEnumerable<Finance> GetAll();
		bool Remove(int id);
		bool RemoveInvestmentDeposit(int investmentId);
		Finance? Update(Finance updateData, int id);
		bool AddInvestmentDeposit(InvestmentDeposit investmentDeposit, int financeId);
	}
}