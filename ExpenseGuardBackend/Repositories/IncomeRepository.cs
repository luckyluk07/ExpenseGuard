using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;

namespace ExpenseGuardBackend.Repositories
{
	public class IncomeRepository : IIncomeRepository
	{
		private readonly ICategoryRepository _categoryRepository;

		private int _lastAddedId = 1;
		private readonly List<Income> _incomes;

		public IncomeRepository(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;

			_incomes = new List<Income>();

			var income1 = new Income()
			{
				Name = "FirstIncome",
				Amount = 100,
				ReceivedDate = DateTime.Now.AddDays(-5),
				Category = _categoryRepository.Get(1)
			};
			var income2 = new Income()
			{
				Name = "SecondIncome",
				Amount = 300,
				ReceivedDate = DateTime.UtcNow.AddDays(-10),
				Category = _categoryRepository.Get(2)
			};
			Create(income1);
			Create(income2);
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
				Amount = income.Amount,
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
			incomeToUpdate.Amount = income.Amount;
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
