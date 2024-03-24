using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Repositories.Incomes;
using ExpenseGuardBackend.Services.Finances;
using ExpenseGuardBackend.Mappers;

namespace ExpenseGuardBackend.Services.Incomes
{
	public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IFinanceService _financeService;
        private readonly EntityMapper _entityMapper;

		public IncomeService(IIncomeRepository incomeRepository, IFinanceService financeService, EntityMapper entityMapper)
		{
			_incomeRepository = incomeRepository;
			_financeService = financeService;
			_entityMapper = entityMapper;
		}

		public List<IncomeDto> GetAll()
        {
            var allIncomes = _incomeRepository.GetAll();
            return _incomeRepository.GetAll()
                .Select(DtoMapper.IncomeToDto)
                .ToList();
        }

        public IncomeDto? Get(int id)
        {
            var income = _incomeRepository.Get(id);
            if (income is null)
            {
                return null;
            }
            return DtoMapper.IncomeToDto(income);
        }

        public IncomeDto Create(CreateIncomeDto income)
        {
            var incomeToCreate = _entityMapper.CreateIncomeDtoToIncome(income);
            var createdIncome = _incomeRepository.Create(incomeToCreate);
            var incomeDto = DtoMapper.IncomeToDto(createdIncome);

            _financeService.Update(new DTOs.Finances.UpdateFinanceDto(new List<IncomeDto>() { incomeDto }, new List<ExpenseDto>()), income.FinanceId);

            return incomeDto;

		}

        public bool Delete(int id)
        {
            return _incomeRepository.Delete(id);
        }

        public IncomeDto? Update(UpdateIncomeDto income, int id)
        {
            var incomeToUpdate = _entityMapper.UpdateIncomeDtoToIncome(income);
            var updatedIncome = _incomeRepository.Update(incomeToUpdate, id);
            if (updatedIncome is null)
            {
                return null;
            }
            return DtoMapper.IncomeToDto(updatedIncome);
        }
    }
}
