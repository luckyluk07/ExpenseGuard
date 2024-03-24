using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Services.Finances;
using ExpenseGuardBackend.Mappers;

namespace ExpenseGuardBackend.Services.Expenses
{
	public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IFinanceService _financeService;
        private readonly EntityMapper _entityMapper;

		public ExpenseService(IExpenseRepository expenseRepository, IFinanceService financeService, EntityMapper entityMapper)
		{
			_expenseRepository = expenseRepository;
			_financeService = financeService;
			_entityMapper = entityMapper;
		}

		public List<ExpenseDto> GetAll()
        {
            return _expenseRepository
                .GetAll()
                .Select(DtoMapper.ExpenseToDto)
                .ToList();
        }

        public ExpenseDto? Get(int id)
        {
            var expense = _expenseRepository.Get(id);
            if (expense is null)
            {
                return null;
            }
            return DtoMapper.ExpenseToDto(expense);

        }

        public ExpenseDto Create(CreateExpenseDto expense)
        {
            var expenseToCreate = _entityMapper.CreateExpenseDtoToExpense(expense);
            var createdExpense = _expenseRepository.Create(expenseToCreate);
            var expenseDto = DtoMapper.ExpenseToDto(createdExpense);

			_financeService.Update(new DTOs.Finances.UpdateFinanceDto(new List<IncomeDto>(), new List<ExpenseDto>() { expenseDto }), expense.FinanceId);

			return expenseDto;
        }

        public ExpenseDto? Update(UpdateExpenseDto expense, int id)
        {
            var expenseToUpdate = _entityMapper.UpdateExpenseDtoToExpense(expense);
            var updatedExpense = _expenseRepository.Update(expenseToUpdate, id);
            if (updatedExpense is null)
            {
                return null;
            }

            return DtoMapper.ExpenseToDto(updatedExpense);
        }

        public bool Delete(int id)
        {
            return _expenseRepository.Delete(id);
        }
    }
}
