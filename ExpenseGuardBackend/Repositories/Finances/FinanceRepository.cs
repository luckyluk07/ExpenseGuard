using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Currencies;

namespace ExpenseGuardBackend.Repositories.Finances
{
	public class FinanceRepository : IFinanceRepository
	{
		private int _lastUsedId;
		private readonly List<Finance> _finances;

		private readonly ICurrencyRepository _currencyRepository;

		public FinanceRepository(ICurrencyRepository currencyRepository)
		{
			_lastUsedId = 0;
			_finances = new List<Finance>();
			_currencyRepository = currencyRepository;
			var fin = new Finance()
			{
				CurrencySavings = new List<Money>() {
					new Money()
					{
						Amount = 10,
						Currency = _currencyRepository.Get(0)
					},
				},
				Expenses = new List<Expense>(), 
				Incomes = new List<Income>(),
				Investments = new List<InvestmentDeposit>()
			};
			Create(fin);
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
				Incomes = new List<Income>(),
				Investments = new List<InvestmentDeposit>()
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

		// todo test below method
		public bool RemoveInvestmentDeposit(int investmentId, int financeId)
		{
			var finance = _finances.FirstOrDefault(x => x.Id == financeId);
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
			return true;

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
