using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;

namespace ExpenseGuardBackend.Services
{
	public class ExpenseService : IExpenseService
	{
		private readonly IExpenseRepository _expenseRepository;

		public ExpenseService(IExpenseRepository expenseRepository)
		{
			_expenseRepository = expenseRepository;
		}

		public List<Expense> GetAll()
		{
			return _expenseRepository.GetAll();
		}

		public Expense? Get(int id)
		{
			return _expenseRepository.Get(id);
		}

		public Expense Create(Expense expense)
		{
			return _expenseRepository.Create(expense);
		}

		public Expense? Update(Expense expense, int id)
		{
			return _expenseRepository.Update(expense, id);
		}

		public bool Delete(int id)
		{
			return _expenseRepository.Delete(id);
		}
	}
}
