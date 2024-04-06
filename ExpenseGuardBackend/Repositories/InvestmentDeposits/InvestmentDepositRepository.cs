using ExpenseGuardBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseGuardBackend.Repositories.InvestmentDeposits
{
	public class InvestmentDepositRepository : IInvestmentDepositRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public InvestmentDepositRepository(ExpenseGuardDbContext expenseGuardDbContext)
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
			return GetFullInvestmentsDeposits()
				.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<InvestmentDeposit> GetAll()
		{
			return GetFullInvestmentsDeposits();
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

		private IEnumerable<InvestmentDeposit> GetFullInvestmentsDeposits()
		{
			return _expenseGuardDbContext.InvestmentsDeposits
				.Include(x => x.StartMoney)
					.ThenInclude(x => x.Currency);
		}
	}
}
