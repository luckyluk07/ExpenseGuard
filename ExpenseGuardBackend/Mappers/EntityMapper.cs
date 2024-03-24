using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;

namespace ExpenseGuardBackend.Mappers
{
	// todo fix possible null reference
	public class EntityMapper
	{
		private readonly ICurrencyRepository _currencyRepository;
		private readonly ICategoryRepository _categoryRepository;

		public EntityMapper(ICurrencyRepository currencyRepository, ICategoryRepository categoryRepository)
		{
			_currencyRepository = currencyRepository;
			_categoryRepository = categoryRepository;
		}

		public Income CreateIncomeDtoToIncome(CreateIncomeDto createIncomeDto)
		{
			return new Income()
			{
				Money = new Money()
				{
					Amount = createIncomeDto.Amount,
					Currency = _currencyRepository.Get(createIncomeDto.CurrencyId)
				},
				Name = createIncomeDto.Name,
				ReceivedDate = createIncomeDto.ReceivedDate,
				Category = _categoryRepository.Get(createIncomeDto.CategoryId)
			};
		}

		public Income UpdateIncomeDtoToIncome(UpdateIncomeDto updateIncomeDto)
		{
			return new Income()
			{
				Money = new Money()
				{
					Amount = updateIncomeDto.Amount,
					Currency = _currencyRepository.Get(updateIncomeDto.CurrencyId)
				},
				ReceivedDate = updateIncomeDto.ReceivedDate,
				Category = _categoryRepository.Get(updateIncomeDto.CategoryId)
			};
		}

		public Expense CreateExpenseDtoToExpense(CreateExpenseDto createExpenseDto)
		{
			return new Expense()
			{
				Name = createExpenseDto.Name,
				Category = _categoryRepository.Get(createExpenseDto.CategoryId),
				Money = new Money()
				{
					Amount = createExpenseDto.Price,
					Currency = _currencyRepository.Get(createExpenseDto.CurrencyId)
				},
				SpendDate = createExpenseDto.SpendDate,
			};
		}

		public Expense UpdateExpenseDtoToExpense(UpdateExpenseDto updateExpenseDto)
		{
			return new Expense()
			{
				Category = _categoryRepository.Get(updateExpenseDto.CategoryId),
				Money = new Money()
				{
					Amount = updateExpenseDto.Price,
					Currency = _currencyRepository.Get(updateExpenseDto.CurrencyId)
				},
				SpendDate = updateExpenseDto.SpendDate,
			};
		}
	}
}
