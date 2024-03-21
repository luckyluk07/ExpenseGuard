using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.InvestmentDeposits
{
	public class InvestmentDepositRepository : IInvestmentDepositRepository
	{
		private int _lastUsedId;
		private List<InvestmentDeposit> _investmentDeposits;

		public InvestmentDepositRepository()
		{
			_lastUsedId = 0;
			_investmentDeposits = new List<InvestmentDeposit>();
		}

		public List<InvestmentDeposit> GetAll()
		{
			return _investmentDeposits;
		}

		public InvestmentDeposit? Get(int id)
		{
			return _investmentDeposits.FirstOrDefault(x => x.Id == id);
		}

		public InvestmentDeposit Create(InvestmentDeposit investmentDeposit)
		{
			var newInvestmentToCreate = new InvestmentDeposit()
			{
				Id = _lastUsedId++,
				YearCapitalizationAmount = investmentDeposit.YearCapitalizationAmount,
				EndDate = investmentDeposit.EndDate,
				InterestRate = investmentDeposit.InterestRate,
				Name = investmentDeposit.Name,
				StartDate = investmentDeposit.StartDate,
				StartMoney = investmentDeposit.StartMoney
			};
			_investmentDeposits.Add(newInvestmentToCreate);
			return newInvestmentToCreate;
		}

		public bool Remove(int id)
		{
			var resultToRemove = Get(id);
			if (resultToRemove is not null)
			{
				_investmentDeposits.Remove(resultToRemove);
				return true;
			}
			return false;
		}
	}
}
