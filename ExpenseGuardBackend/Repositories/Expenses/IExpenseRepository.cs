using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Expenses
{
    public interface IExpenseRepository
    {
        Expense Create(Expense expenseToAdd);
        bool Delete(int id);
        Expense? Get(int id);
		IEnumerable<Expense> GetAll();
        Expense? Update(Expense expenseToUpdate, int id);
    }
}