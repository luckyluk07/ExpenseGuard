using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;

namespace ExpenseGuardBackend.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public List<ExpenseDto> GetAll()
        {
            return _expenseRepository
                .GetAll()
                .Select(x => new ExpenseDto(x.Id, x.Name, x.Category, x.Price, x.SpendDate))
                .ToList(); ;
        }

        public ExpenseDto? Get(int id)
        {
            var expense = _expenseRepository.Get(id);
            if (expense is null)
            {
                return null;
            }
            return new ExpenseDto(expense.Id, expense.Name, expense.Category, expense.Price, expense.SpendDate);

        }

        public ExpenseDto Create(CreateExpenseDto expense)
        {
            var expenseToCreate = new Expense()
            {
                Name = expense.Name,
                Category = expense.Category,
                Price = expense.Price,
                SpendDate = expense.SpendDate,
            };
            var createdExpense =  _expenseRepository.Create(expenseToCreate);
			return new ExpenseDto(createdExpense.Id, createdExpense.Name, createdExpense.Category, createdExpense.Price, createdExpense.SpendDate);
		}

        public ExpenseDto? Update(UpdateExpenseDto expense, int id)
        {
			var expenseToUpdate = new Expense()
			{
				Category = expense.Category,
				Price = expense.Price,
				SpendDate = expense.SpendDate,
			};

			var updatedExpense =  _expenseRepository.Update(expenseToUpdate, id);
            if (updatedExpense is null) 
            {
                return null;
            }

			return new ExpenseDto(updatedExpense.Id, updatedExpense.Name, updatedExpense.Category, updatedExpense.Price, updatedExpense.SpendDate);
		}

        public bool Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }
    }
}
