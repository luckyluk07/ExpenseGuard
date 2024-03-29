﻿using ExpenseGuardBackend.DTOs.InvestmentDeposits;
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
			var investmentDeposit = _entityMapper.CreateInvestmentDepositDtoToInvestmentDeposit(createInvestmentDepositDto);
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
