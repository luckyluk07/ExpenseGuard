﻿using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Repositories.CompanyShares
{
	public interface ICompanyShareRepository
	{
		CompanyShare? Create(CompanyShare companyShare);
		CompanyShare? Update(CompanyShare companyShare, int id);
		CompanyShare? Get(int id);
		List<CompanyShare> GetAll();
		bool Remove(int id);
	}
}