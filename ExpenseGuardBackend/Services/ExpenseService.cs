using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;
using ExpenseGuardBackend.Repositories.Categories;

namespace ExpenseGuardBackend.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
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
                Category = _categoryRepository.Get(expense.CategoryId),
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
				Category = _categoryRepository.Get(expense.CategoryId),
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
            var categoryDto = new CategoryDto(expense.Category.Id, expense.Category.Name, expense.Category.Description);
			return new ExpenseDto(expense.Id, expense.Name, categoryDto, expense.Price, expense.SpendDate);
		}
	}
}
