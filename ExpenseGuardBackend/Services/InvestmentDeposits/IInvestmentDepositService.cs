using ExpenseGuardBackend.DTOs.CompanyShares;
using ExpenseGuardBackend.DTOs.InvestmentDeposits;

namespace ExpenseGuardBackend.Services.InvestmentDeposits
{
	public interface IInvestmentDepositService
	{
		InvestmentDepositDto? Get(int id);
		IEnumerable<InvestmentDepositDto> GetAll();
		bool Remove(int id);
		InvestmentDepositDto Create(CreateInvestmentDepositDto createInvestmentDepositDto);
		InvestmentDepositDto? Update(UpdateInvestmentDepositDto updateInvestmentDepositDto, int id);
	}
}