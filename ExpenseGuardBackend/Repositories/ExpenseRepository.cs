using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;

namespace ExpenseGuardBackend.Repositories
{
	public class ExpenseRepository : IExpenseRepository
	{
		private readonly ICategoryRepository _categoryRepository;

		private int _lastElementId = 1;
		private readonly List<Expense> _expenses;
		public ExpenseRepository(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
			_expenses = new List<Expense>();

			var expense1 = new Expense()
			{
				Name = "name1",
				Price = 10.1m,
				Category = _categoryRepository.Get(1),
				SpendDate = DateTime.Now
			};

			var expense2 = new Expense()
			{
				Name = "name2",
				Price = 20.1m,
				Category = _categoryRepository.Get(2),
				SpendDate = DateTime.Now
			};

			Create(expense1);
			Create(expense2);
		}

		public List<Expense> GetAll()
		{
			return _expenses;
		}

		public Expense? Get(int id)
		{
			var selectedExpense = GetExpense(id);
			if (selectedExpense is not null)
			{
				return selectedExpense;
			}
			return null;
		}

		public bool Delete(int id)
		{
			var expenseToDelete = GetExpense(id);
			if (expenseToDelete is not null)
			{
				_expenses.Remove(expenseToDelete);
				return true;
			}
			return false;
		}

		public Expense Create(Expense expenseToAdd)
		{
			var newExpense = new Expense()
			{
				Id = _lastElementId++,
				Name = expenseToAdd.Name,
				SpendDate = expenseToAdd.SpendDate,
				Category = expenseToAdd.Category,
				Price = expenseToAdd.Price
			};
			_expenses.Add(newExpense);
			return newExpense;
		}

		public Expense? Update(Expense expenseToUpdate, int id)
		{
			var expense = GetExpense(id);
			if (expense is null)
			{
				return null;
			}

			expense.SpendDate = expenseToUpdate.SpendDate;
			expense.Category = expenseToUpdate.Category;
			expense.Price = expenseToUpdate.Price;

			return expense;
		}

		private Expense? GetExpense(int id)
		{
			return _expenses.FirstOrDefault(x => x.Id == id);
		}
	}
}
