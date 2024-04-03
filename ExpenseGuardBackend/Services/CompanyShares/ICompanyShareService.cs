using ExpenseGuardBackend.DTOs.CompanyShares;

namespace ExpenseGuardBackend.Services.CompanyShares
{
	public interface ICompanyShareService
	{
		CompanyShareDto? Create(CreateCompanyShareDto createCompanyShareDto);
		CompanyShareDto? Get(int id);
		List<CompanyShareDto> GetAll();
		bool Remove(int id);
		CompanyShareDto? Update(UpdateCompanyShareDto updateCompanyShareDto, int id);
	}
}