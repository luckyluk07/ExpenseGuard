using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.InvestmentDeposits;
using ExpenseGuardBackend.Shared;

namespace ExpenseGuardBackend.Services.InvestmentDeposits
{
	public class InvestmentDepositService : IInvestmentDepositService
	{
		private readonly IInvestmentDepositRepository _investmentDepositRepository;
		private readonly IFinanceRepository _financeRepository;
		private readonly ICurrencyRepository _currencyRepository;


		public InvestmentDepositService(IInvestmentDepositRepository investmentDepositRepository, IFinanceRepository financeRepository, ICurrencyRepository currencyRepository)
		{
			_investmentDepositRepository = investmentDepositRepository;
			_financeRepository = financeRepository;
			_currencyRepository = currencyRepository;
		}

		public List<InvestmentDepositDto> GetAll()
		{
			return _investmentDepositRepository.GetAll()
				.Select(DtoMapper.InvestmentDepositToDto)
				.ToList();
		}

		public InvestmentDepositDto? Get(int id)
		{
			var investment = _investmentDepositRepository.Get(id);
			return investment is not null ? DtoMapper.InvestmentDepositToDto(investment) : null;
		}

		// todo test below
		public InvestmentDepositDto Create(CreateInvestmentDepositDto createInvestmentDepositDto)
		{
			// todo add entity model mapper
			var investmentDeposit = new InvestmentDeposit()
			{
				YearCapitalizationAmount = createInvestmentDepositDto.YearCapitalizationAmount,
				EndDate = createInvestmentDepositDto.EndDate,
				InterestRate = createInvestmentDepositDto.InterestRate,
				Name = createInvestmentDepositDto.Name,
				StartDate = createInvestmentDepositDto.StartDate,
				StartMoney = new Money()
				{
					Amount = createInvestmentDepositDto.StartMoney.Amount,
					Currency = _currencyRepository.Get(createInvestmentDepositDto.StartMoney.CurrencyId)					
				}
			};
			var createdInvestment = _investmentDepositRepository.Create(investmentDeposit);

			_financeRepository.AddInvestmentDeposit(createdInvestment, createInvestmentDepositDto.FinanceId);

			return DtoMapper.InvestmentDepositToDto(createdInvestment);
		}

		// todo test below
		public bool Remove(int id, int financeId)
		{
			var isDepositRemoved = _financeRepository.RemoveInvestmentDeposit(id, financeId);
			if (!isDepositRemoved)
			{
				return false;
			}
			return _investmentDepositRepository.Remove(id);
		}
	}
}
