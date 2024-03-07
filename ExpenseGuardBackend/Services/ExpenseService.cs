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
                .Select(ExpenseToDto)
                .ToList();
        }

        public ExpenseDto? Get(int id)
        {
            var expense = _expenseRepository.Get(id);
            if (expense is null)
            {
                return null;
            }
            return ExpenseToDto(expense);

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
			return ExpenseToDto(createdExpense);
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

			return ExpenseToDto(updatedExpense);
		}

        public bool Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }

        private ExpenseDto ExpenseToDto(Expense expense)
        {
			return new ExpenseDto(expense.Id, expense.Name, expense.Category, expense.Price, expense.SpendDate);
		}
	}
}
