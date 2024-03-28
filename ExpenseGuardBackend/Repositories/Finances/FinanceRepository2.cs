﻿using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public class FinanceRepository2 : IFinanceRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public FinanceRepository2(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public bool AddInvestmentDeposit(InvestmentDeposit investmentDeposit, int financeId)
		{
			var finance = Get(financeId);
			if (finance is null)
			{
				return false;
			}

			finance.Investments.Add(investmentDeposit);
			_expenseGuardDbContext.SaveChanges();
			return true;
		}

		public Finance Create(Finance newFinance)
		{
			var financeToAdd = new Finance()
			{
				CurrencySavings = newFinance.CurrencySavings,
				Expenses = new List<Expense>(),
				Incomes = new List<Income>(),
				Investments = new List<InvestmentDeposit>()
			};
			_expenseGuardDbContext.Finances.Add(newFinance);
			_expenseGuardDbContext.SaveChanges();
			return financeToAdd;
		}

		public Finance? Get(int id)
		{
			return _expenseGuardDbContext.Finances
				.FirstOrDefault(x => x.Id == id);
		}

		public List<Finance> GetAll()
		{
			return _expenseGuardDbContext.Finances
				.ToList();
		}

		public bool Remove(int id)
		{
			var financeToDelete = Get(id);
			if (financeToDelete is null)
			{
				return false;
			}

			_expenseGuardDbContext.Finances.Remove(financeToDelete);
			_expenseGuardDbContext.SaveChanges();
			return true;
		}

		public bool RemoveInvestmentDeposit(int investmentId, int financeId)
		{
			var finance = Get(financeId);
			if (finance is null)
			{
				return false;
			}

			var investment = finance.Investments.FirstOrDefault(x => x.Id == investmentId);
			if (investment is null)
			{
				return false;
			}

			var currencyToUpdate = finance.CurrencySavings.FirstOrDefault(x => x.Currency.Code == investment.StartMoney.Currency.Code);
			if (currencyToUpdate is null)
			{
				finance.CurrencySavings.Add(new Money()
				{
					Amount = 0,
					Currency = currencyToUpdate.Currency
				});
			}
			else
			{
				currencyToUpdate.Amount += investment.StartMoney.Amount;
			}

			finance.Investments.Remove(investment);
			_expenseGuardDbContext.SaveChanges();
			return true;
		}

		public Finance? Update(Finance updateData, int id)
		{
			var financeToUpdate = Get(id);
			if (financeToUpdate is null)
			{
				return null;
			};

			financeToUpdate.CurrencySavings = updateData.CurrencySavings;
			financeToUpdate.Expenses = updateData.Expenses;
			financeToUpdate.Incomes = updateData.Incomes;

			_expenseGuardDbContext.SaveChanges();

			return financeToUpdate;
		}
	}
}
