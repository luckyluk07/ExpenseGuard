using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.CompanyShares
{
	public class CompanyShareRepository : ICompanyShareRepository
	{
		private readonly ExpenseGuardDbContext _expenseGuardDbContext;

		public CompanyShareRepository(ExpenseGuardDbContext expenseGuardDbContext)
		{
			_expenseGuardDbContext = expenseGuardDbContext;
		}

		public List<CompanyShare> GetAll()
		{
			return _expenseGuardDbContext.CompanyShares.ToList();
		}

		public CompanyShare? Get(int id)
		{
			return _expenseGuardDbContext.CompanyShares.FirstOrDefault(x => x.Id == id);
		}

		public CompanyShare? Create(CompanyShare companyShare)
		{
			var result = _expenseGuardDbContext.CompanyShares.Add(companyShare);
			_expenseGuardDbContext.SaveChanges();
			return result.Entity;
		}

		public bool Remove(int id)
		{
			var toRemove = _expenseGuardDbContext.CompanyShares.FirstOrDefault(x => x.Id == id);
			if (toRemove is null)
			{
				return false;
			}
			_expenseGuardDbContext.CompanyShares.Remove(toRemove);
			_expenseGuardDbContext.SaveChanges();
			return true;
		}
	}
}
