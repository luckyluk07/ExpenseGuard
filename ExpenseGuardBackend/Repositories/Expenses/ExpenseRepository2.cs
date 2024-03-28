using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Expenses
{
	public class ExpenseRepository2 : IExpenseRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public ExpenseRepository2(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public Expense Create(Expense expenseToAdd)
		{
			var newExpense = new Expense()
			{
				Name = expenseToAdd.Name,
				SpendDate = expenseToAdd.SpendDate,
				Category = expenseToAdd.Category,
				Money = expenseToAdd.Money
			};
			_expenseGuardDbContext.Expenses.Add(newExpense);
			_expenseGuardDbContext.SaveChanges();
			return newExpense;
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
			return _expenseGuardDbContext.Expenses
				.FirstOrDefault(x => x.Id == id);
		}

		public List<Expense> GetAll()
		{
			return _expenseGuardDbContext.Expenses
				.ToList();
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
	}
}
