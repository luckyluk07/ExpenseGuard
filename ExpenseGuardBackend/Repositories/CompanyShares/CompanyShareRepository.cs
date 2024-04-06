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

		public IEnumerable<CompanyShare> GetAll()
		{
			return _expenseGuardDbContext.CompanyShares;
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

		public CompanyShare? Update(CompanyShare companyShare, int id)
		{
			var companyToUpdate = Get(id);
			if (companyToUpdate is null)
			{
				return null;
			}

			companyToUpdate.Amount = companyShare.Amount;
			companyToUpdate.DateOfPurchase = companyShare.DateOfPurchase;
			companyToUpdate.Name = companyShare.Name;
			companyToUpdate.Price = companyShare.Price;
			_expenseGuardDbContext.SaveChanges();

			return companyToUpdate;
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
