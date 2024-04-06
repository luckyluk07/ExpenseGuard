using ExpenseGuardBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public class FinanceRepository : IFinanceRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public FinanceRepository(ExpenseGuardDbContext expenseGuardDbContext)
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
			return GetFullFinances()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Finance> GetAll()
		{
			return GetFullFinances();
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

		private IEnumerable<Finance> GetFullFinances()
		{
			return _expenseGuardDbContext.Finances
				.Include(x => x.Incomes)
					.ThenInclude(x => x.Money)
					.ThenInclude(x => x.Currency)
				.Include(x => x.Incomes)
					.ThenInclude(x => x.Category)
				.Include(x => x.Expenses)
					.ThenInclude(x => x.Money)
					.ThenInclude(x => x.Currency)
				.Include(x => x.Expenses)
					.ThenInclude(x => x.Category)
				.Include(x => x.CurrencySavings)
				.Include(x => x.Investments)
					.ThenInclude(x => x.StartMoney);
		}
	}
}
