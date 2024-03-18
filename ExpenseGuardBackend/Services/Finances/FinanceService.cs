using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Shared;

namespace ExpenseGuardBackend.Services.Finances
{
	public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _financeRepository;

        public FinanceService(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public List<FinanceDto> GetFinances()
        {
            var finances = _financeRepository.GetAll();

            return finances
                .Select(DtoMapper.FinanceToDto)
                .ToList();
        }

        public FinanceDto? GetFinance(int id)
        {
            var finance = _financeRepository.Get(id);
            if (finance is null)
            {
                return null;
            }

            return DtoMapper.FinanceToDto(finance);
        }

        // todo create finance dto modify
        //public FinanceDto Create(CreateFinanceDto createFinanceDto)
        //{
        //	var financeToCreate = new Finance()
        //	{
        //		CurrencySavings = createFinanceDto.CurrencySavings.,
        //		Expenses = new List<Expense>(),
        //		Incomes = new List<Income>()
        //	};

        //	var createdFinance = _financeRepository.Create(financeToCreate);

        //	return FinanceToDto(createdFinance);

        //}

        public bool Remove(int id)
        {
            return _financeRepository.Remove(id);
        }
    }
}
