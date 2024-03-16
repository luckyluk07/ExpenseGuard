﻿using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public class FinanceRepository : IFinanceRepository
	{
		private int _lastUsedId;
		private readonly List<Finance> _finances;

		public FinanceRepository()
		{
			_lastUsedId = 0;
			_finances = new List<Finance>();
		}

		public List<Finance> GetAll()
		{
			return _finances;
		}

		public Finance? Get(int id)
		{
			return _finances.FirstOrDefault(x => x.Id == id);
		}

		public Finance Create(Finance newFinance)
		{
			var financeToAdd = new Finance()
			{
				Id = _lastUsedId++,
				CurrencySavings = newFinance.CurrencySavings,
				Expenses = new List<Expense>(),
				Incomes = new List<Income>()
			};
			_finances.Add(newFinance);
			return financeToAdd;
		}

		public Finance? Update(Finance updateData, int id)
		{
			var financeToUpdate = _finances.FirstOrDefault(x => x.Id == id);
			if (financeToUpdate is null)
			{
				return null;
			};

			financeToUpdate.CurrencySavings = updateData.CurrencySavings;
			financeToUpdate.Expenses = updateData.Expenses;
			financeToUpdate.Incomes = updateData.Incomes;

			return financeToUpdate;
		}

		public bool Remove(int id)
		{
			var financeToDelete = _finances.FirstOrDefault(x => x.Id == id);
			if (financeToDelete is null)
			{
				return false;
			}

			_finances.Remove(financeToDelete);
			return true;
		}
	}
}