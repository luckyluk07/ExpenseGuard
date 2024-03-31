using ExpenseGuardBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseGuardBackend.Repositories.Incomes
{
	// todo test below
	// todo add initial values
	// todo replace that with repository
	public class IncomeRepository : IIncomeRepository
	{
		private readonly ExpenseGuardDbContext _context;

		public IncomeRepository(ExpenseGuardDbContext context)
		{
			_context = context;
		}

		public Income Create(Income income)
		{
			var newIncome = new Income()
			{
				Name = income.Name,
				Money = income.Money,
				ReceivedDate = income.ReceivedDate,
				Category = income.Category
			};
			_context.Incomes.Add(newIncome);
			_context.SaveChanges();
			return newIncome;
		}

		public bool Delete(int id)
		{
			var incomeToDelete = Get(id);
			if (incomeToDelete is null)
			{
				return false;
			}
			_context.Incomes.Remove(incomeToDelete);
			_context.SaveChanges();
			return true;
		}

		public Income? Get(int id)
		{
			return GetFullIncomes().FirstOrDefault(x => x.Id == id);
		}

		public List<Income> GetAll()
		{
			return GetFullIncomes().ToList();
		}

		public Income? Update(Income income, int id)
		{
			var incomeToUpdate = Get(id);
			if (incomeToUpdate is null)
			{
				return null;
			}

			incomeToUpdate.ReceivedDate = income.ReceivedDate;
			incomeToUpdate.Money = income.Money;
			incomeToUpdate.Category = income.Category;
			_context.SaveChanges();
			return incomeToUpdate;
		}

		public IEnumerable<Income> GetFullIncomes()
		{
			return _context.Incomes
				.Include(x => x.Category)
				.Include(x => x.Money)
					.ThenInclude(x => x.Currency);
		}
	}
}
