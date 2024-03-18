using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Shared;

namespace ExpenseGuardBackend.Services.Expenses
{
	public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrencyRepository _currencyRepository;

		public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICurrencyRepository currencyRepository)
		{
			_expenseRepository = expenseRepository;
			_categoryRepository = categoryRepository;
			_currencyRepository = currencyRepository;
		}

		public List<ExpenseDto> GetAll()
        {
            return _expenseRepository
                .GetAll()
                .Select(DtoMapper.ExpenseToDto)
                .ToList();
        }

        public ExpenseDto? Get(int id)
        {
            var expense = _expenseRepository.Get(id);
            if (expense is null)
            {
                return null;
            }
            return DtoMapper.ExpenseToDto(expense);

        }

        public ExpenseDto Create(CreateExpenseDto expense)
        {
            var expenseToCreate = new Expense()
            {
                Name = expense.Name,
                Category = _categoryRepository.Get(expense.CategoryId),
				Money = new Money()
				{
					Amount = expense.Price,
					Currency = _currencyRepository.Get(expense.CurrencyId)
				},
				SpendDate = expense.SpendDate,
            };
            var createdExpense = _expenseRepository.Create(expenseToCreate);
            return DtoMapper.ExpenseToDto(createdExpense);
        }

        public ExpenseDto? Update(UpdateExpenseDto expense, int id)
        {
            var expenseToUpdate = new Expense()
            {
                Category = _categoryRepository.Get(expense.CategoryId),
                Money = new Money()
                {
                    Amount = expense.Price,
                    Currency = _currencyRepository.Get(expense.CurrencyId)
                },
                SpendDate = expense.SpendDate,
            };

            var updatedExpense = _expenseRepository.Update(expenseToUpdate, id);
            if (updatedExpense is null)
            {
                return null;
            }

            return DtoMapper.ExpenseToDto(updatedExpense);
        }

        public bool Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }
    }
}
