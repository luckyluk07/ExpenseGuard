using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Money;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;

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
				Money = new Money()
				{
					Amount = expense.Price,
					Currency = _currencyRepository.Get(expense.CurrencyId)
				},
				SpendDate = expense.SpendDate,
            };
            var createdExpense = _expenseRepository.Create(expenseToCreate);
            return ExpenseToDto(createdExpense);
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

            return ExpenseToDto(updatedExpense);
        }

        public bool Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }

        private ExpenseDto ExpenseToDto(Expense expense)
        {
			var currencyDto = new CurrencyDto(expense.Money.Currency.Id, expense.Money.Currency.Name, expense.Money.Currency.Code, expense.Money.Currency.Country);
			var moneyDto = new MoneyDto(expense.Money.Amount, currencyDto);
			var categoryDto = new CategoryDto(expense.Category.Id, expense.Category.Name, expense.Category.Description);
            return new ExpenseDto(expense.Id, expense.Name, categoryDto, moneyDto, expense.SpendDate);
        }
    }
}
