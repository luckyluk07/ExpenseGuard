using ExpenseGuardBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseGuardBackend.Repositories.Expenses
{
	public class ExpenseRepository : IExpenseRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public ExpenseRepository(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public Expense Create(Expense expenseToAdd)
		{
			var newExpense = _expenseGuardDbContext.Expenses.Add(expenseToAdd);
			_expenseGuardDbContext.SaveChanges();
			return newExpense.Entity;
		}

		public bool Delete(int id)
		{
			var expenseToDelete = Get(id);
			if (expenseToDelete is not null)
			{
				_expenseGuardDbContext.Expenses.Remove(expenseToDelete);
				_expenseGuardDbContext.SaveChanges();
				return true;
			}
			return false;
		}

		public Expense? Get(int id)
		{
			return GetFullExpenses()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Expense> GetAll()
		{
			return GetFullExpenses();
		}

		public Expense? Update(Expense expenseToUpdate, int id)
		{
			var expense = Get(id);
			if (expense is null)
			{
				return null;
			}

			expense.SpendDate = expenseToUpdate.SpendDate;
			expense.Category = expenseToUpdate.Category;
			expense.Money = expenseToUpdate.Money;

			_expenseGuardDbContext.SaveChanges();

			return expense;
		}

		private IEnumerable<Expense> GetFullExpenses()
		{
			return _expenseGuardDbContext.Expenses
					.Include(x => x.Money)
						.ThenInclude(x => x.Currency)
					.Include(x => x.Category);
		}
	}
}
