using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Services
{
	public interface IExpenseService
	{
		Expense Create(Expense expense);
		bool Delete(int id);
		Expense? Get(int id);
		List<Expense> GetAll();
		Expense? Update(Expense expense, int id);
	}
}