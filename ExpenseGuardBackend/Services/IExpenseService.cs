using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Services
{
    public interface IExpenseService
    {
		ExpenseDto Create(CreateExpenseDto expense);
        bool Delete(int id);
        ExpenseDto? Get(int id);
        List<ExpenseDto> GetAll();
		ExpenseDto? Update(UpdateExpenseDto expense, int id);
    }
}