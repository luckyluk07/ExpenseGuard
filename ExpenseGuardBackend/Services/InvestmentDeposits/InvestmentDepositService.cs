using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.InvestmentDeposits;
using ExpenseGuardBackend.Mappers;

namespace ExpenseGuardBackend.Services.InvestmentDeposits
{
	public class InvestmentDepositService : IInvestmentDepositService
	{
		private readonly IInvestmentDepositRepository _investmentDepositRepository;
		private readonly IFinanceRepository _financeRepository;
		private readonly EntityMapper _entityMapper;


		public InvestmentDepositService(IInvestmentDepositRepository investmentDepositRepository, IFinanceRepository financeRepository, EntityMapper entityMapper)
		{
			_investmentDepositRepository = investmentDepositRepository;
			_financeRepository = financeRepository;
			_entityMapper = entityMapper;
		}

		public IEnumerable<InvestmentDepositDto> GetAll()
		{
			return _investmentDepositRepository.GetAll()
				.Select(DtoMapper.InvestmentDepositToDto);
		}

		public InvestmentDepositDto? Get(int id)
		{
			var investment = _investmentDepositRepository.Get(id);
			return investment is not null ? DtoMapper.InvestmentDepositToDto(investment) : null;
		}

		public InvestmentDepositDto Create(CreateInvestmentDepositDto createInvestmentDepositDto)
		{
			var investmentDeposit = _entityMapper.CreateInvestmentDepositDtoToInvestmentDeposit(createInvestmentDepositDto);
			var createdInvestment = _investmentDepositRepository.Create(investmentDeposit);

			_financeRepository.AddInvestmentDeposit(createdInvestment, createInvestmentDepositDto.FinanceId);

			return DtoMapper.InvestmentDepositToDto(createdInvestment);
		}

		public bool Remove(int id)
		{
			return _investmentDepositRepository.Remove(id);
		}
	}
}
