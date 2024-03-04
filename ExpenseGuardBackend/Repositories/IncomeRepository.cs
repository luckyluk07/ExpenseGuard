using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories
{
	public class IncomeRepository : IIncomeRepository
	{
		private int _lastAddedId = 1;
		private readonly List<Income> _incomes;

		public IncomeRepository()
		{
			_incomes = new List<Income>();

			var income1 = new Income()
			{
				Name = "FirstIncome",
				Amount = 100,
				ReceivedDate = DateTime.Now.AddDays(-5),
			};
			var income2 = new Income()
			{
				Name = "SecondIncome",
				Amount = 300,
				ReceivedDate = DateTime.UtcNow.AddDays(-10),
			};
			_incomes.Add(income1);
			_incomes.Add(income2);
		}

		public List<Income> GetAll()
		{
			return _incomes
				.Select(x => (Income)x.Clone())
				.ToList();
		}

		public Income? Get(int id)
		{
			var income = GetIncome(id);
			if (income is null)
			{
				return null;
			}
			return (Income)income.Clone();
		}

		public Income Create(Income income)
		{
			var newIncome = new Income()
			{
				Id = _lastAddedId++,
				Name = income.Name,
				Amount = income.Amount,
				ReceivedDate = income.ReceivedDate,
			};
			_incomes.Add(newIncome);
			return (Income)newIncome.Clone();
		}

		public Income? Update(Income income, int id)
		{
			var incomeToUpdate = GetIncome(id);
			if (incomeToUpdate is null)
			{
				return null;
			}

			incomeToUpdate.ReceivedDate = income.ReceivedDate;
			incomeToUpdate.Name = income.Name;
			incomeToUpdate.Amount = income.Amount;
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
