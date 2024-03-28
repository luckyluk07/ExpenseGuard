using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.InvestmentDeposits
{
	public class InvestmentDepositRepository2 : IInvestmentDepositRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public InvestmentDepositRepository2(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public InvestmentDeposit Create(InvestmentDeposit investmentDeposit)
		{
			var newInvestmentToCreate = new InvestmentDeposit()
			{
				YearCapitalizationAmount = investmentDeposit.YearCapitalizationAmount,
				EndDate = investmentDeposit.EndDate,
				InterestRate = investmentDeposit.InterestRate,
				Name = investmentDeposit.Name,
				StartDate = investmentDeposit.StartDate,
				StartMoney = investmentDeposit.StartMoney
			};
			_expenseGuardDbContext.InvestmentsDeposits.Add(newInvestmentToCreate);
			_expenseGuardDbContext.SaveChanges();
			return newInvestmentToCreate;
		}

		public InvestmentDeposit? Get(int id)
		{
			return _expenseGuardDbContext.InvestmentsDeposits
				.FirstOrDefault(x => x.Id == id);
		}

		public List<InvestmentDeposit> GetAll()
		{
			return _expenseGuardDbContext.InvestmentsDeposits
				.ToList();
		}

		public bool Remove(int id)
		{
			var resultToRemove = Get(id);
			if (resultToRemove is not null)
			{
				_expenseGuardDbContext.InvestmentsDeposits.Remove(resultToRemove);
				_expenseGuardDbContext.SaveChanges();
				return true;
			}
			return false;
		}
	}
}
