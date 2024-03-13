using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;

namespace ExpenseGuardBackend.Repositories.Incomes
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrencyRepository _currencyRepository;

        private int _lastAddedId = 1;
        private readonly List<Income> _incomes;

		public IncomeRepository(ICategoryRepository categoryRepository, ICurrencyRepository currencyRepository)
		{
			_categoryRepository = categoryRepository;
            _currencyRepository = currencyRepository;

			_incomes = new List<Income>();

			var income1 = new Income()
			{
				Name = "FirstIncome",
				Money = new Money()
				{
					Amount = 100,
					Currency = _currencyRepository.Get(1)
				},
				ReceivedDate = DateTime.Now.AddDays(-5),
				Category = _categoryRepository.Get(1)
			};
			var income2 = new Income()
			{
				Name = "SecondIncome",
				Money = new Money()
				{
					Amount = 300,
					Currency = _currencyRepository.Get(1)
				},
				ReceivedDate = DateTime.UtcNow.AddDays(-10),
				Category = _categoryRepository.Get(2)
			};
			Create(income1);
			Create(income2);
			_currencyRepository = currencyRepository;
		}

		public List<Income> GetAll()
        {
            return _incomes;
        }

        public Income? Get(int id)
        {
            var income = GetIncome(id);
            if (income is null)
            {
                return null;
            }
            return income;
        }

        public Income Create(Income income)
        {
            var newIncome = new Income()
            {
                Id = _lastAddedId++,
                Name = income.Name,
                Money = income.Money,
                ReceivedDate = income.ReceivedDate,
                Category = income.Category
            };
            _incomes.Add(newIncome);
            return newIncome;
        }

        public Income? Update(Income income, int id)
        {
            var incomeToUpdate = GetIncome(id);
            if (incomeToUpdate is null)
            {
                return null;
            }

            incomeToUpdate.ReceivedDate = income.ReceivedDate;
            incomeToUpdate.Money = income.Money;
            incomeToUpdate.Category = income.Category;
            return incomeToUpdate;
        }

        public bool Delete(int id)
        {
            var incomeToDelete = _incomes.FirstOrDefault(x => x.Id == id);
            if (incomeToDelete is null)
            {
                return false;
            }
            _incomes.Remove(incomeToDelete);
            return true;

        }

        private Income? GetIncome(int id)
        {
            return _incomes
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
