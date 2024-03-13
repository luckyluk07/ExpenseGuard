using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.Money;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Incomes;

namespace ExpenseGuardBackend.Services.Incomes
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrencyRepository _currencyRepository;

		public IncomeService(IIncomeRepository incomeRepository, ICategoryRepository categoryRepository, ICurrencyRepository currencyRepository)
		{
			_incomeRepository = incomeRepository;
			_categoryRepository = categoryRepository;
			_currencyRepository = currencyRepository;
		}

		public List<IncomeDto> GetAll()
        {
            var allIncomes = _incomeRepository.GetAll();
            return _incomeRepository.GetAll()
                .Select(IncomeToDto)
                .ToList();
        }

        public IncomeDto? Get(int id)
        {
            var income = _incomeRepository.Get(id);
            if (income is null)
            {
                return null;
            }
            return IncomeToDto(income);
        }

        public IncomeDto Create(CreateIncomeDto income)
        {
            var incomeToCreate = new Income()
            {
				Money = new Money()
				{
					Amount = income.Amount,
					Currency = _currencyRepository.Get(income.CurrencyId)
				},
				Name = income.Name,
                ReceivedDate = income.ReceivedDate,
                Category = _categoryRepository.Get(income.CategoryId)
            };

            var createdIncome = _incomeRepository.Create(incomeToCreate);
            return IncomeToDto(createdIncome);
        }

        public bool Delete(int id)
        {
            return _incomeRepository.Delete(id);
        }

        public IncomeDto? Update(UpdateIncomeDto income, int id)
        {
            var incomeToUpdate = new Income()
            {
                Money = new Money()
                {
                    Amount = income.Amount,
                    Currency = _currencyRepository.Get(income.CurrencyId)
                },
                ReceivedDate = income.ReceivedDate,
                Category = _categoryRepository.Get(income.CategoryId)
            };
            var updatedIncome = _incomeRepository.Update(incomeToUpdate, id);
            if (updatedIncome is null)
            {
                return null;
            }
            return IncomeToDto(updatedIncome);
        }

        private IncomeDto IncomeToDto(Income income)
        {
            var currencyDto = new CurrencyDto(income.Money.Currency.Id, income.Money.Currency.Name, income.Money.Currency.Code, income.Money.Currency.Country);
            var moneyDto = new MoneyDto(income.Money.Amount, currencyDto);
            var categoryDto = new CategoryDto(income.Category.Id, income.Category.Name, income.Category.Description);
            return new IncomeDto(income.Id, income.Name, income.ReceivedDate, moneyDto, categoryDto);
        }
    }
}
