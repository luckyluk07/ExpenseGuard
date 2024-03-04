using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories
{
	public interface IIncomeRepository
	{
		Income Create(Income income);
		bool Delete(int id);
		Income? Get(int id);
		List<Income> GetAll();
		Income? Update(Income income, int id);
	}
}