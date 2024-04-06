using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.Incomes;
using ExpenseGuardBackend.Mappers;
using System.Data;

namespace ExpenseGuardBackend.Services.Finances
{
	public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _financeRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;

		public FinanceService(IFinanceRepository financeRepository, ICurrencyRepository currencyRepository, IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
		{
			_financeRepository = financeRepository;
			_currencyRepository = currencyRepository;
			_incomeRepository = incomeRepository;
			_expenseRepository = expenseRepository;
		}

		public IEnumerable<FinanceDto> GetFinances()
        {
            var finances = _financeRepository.GetAll();

            return finances
                .Select(DtoMapper.FinanceToDto);
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

        public FinanceDto Create(CreateFinanceDto createFinanceDto)
        {
            var currencySaving = createFinanceDto.CurrencySavings.Select(x => new Money()
            {
                Amount = x.Amount,
                Currency = _currencyRepository.Get(x.CurrencyId)
            }).ToList();
            var financeToCreate = new Finance()
            {
                CurrencySavings = currencySaving,
                Expenses = new List<Expense>(),
                Incomes = new List<Income>(),
                Investments = new List<InvestmentDeposit>()
            };

            var createdFinance = _financeRepository.Create(financeToCreate);

            return DtoMapper.FinanceToDto(createdFinance);
        }

		public FinanceDto? Update(UpdateFinanceDto finance, int id)
		{
            var currentFinance = _financeRepository.Get(id);
			if (currentFinance is null)
			{
				return null;
			}

			var newExpenses = finance.Expenses.Select(x => _expenseRepository.Get(x.Id)).ToList();
			var newIncomes = finance.Incomes.Select(x => _incomeRepository.Get(x.Id)).ToList();

            foreach (var currencyMoney in currentFinance.CurrencySavings)
            {
				foreach (var income in newIncomes)
				{
					if (income?.Money.Currency.Code == currencyMoney.Currency.Code)
					{
						currencyMoney.Amount += income.Money.Amount;
					}
				}
				foreach (var expense in newExpenses)
                {
					if (expense?.Money.Currency.Code == currencyMoney.Currency.Code)
					{
						currencyMoney.Amount -= expense.Money.Amount;
					}
				}
            }


			var financeToUpdate = new Finance()
            {
                Id = id,
                CurrencySavings = currentFinance.CurrencySavings,
				Expenses = new List<Expense>(currentFinance.Expenses.Concat(newExpenses)),
                Incomes = new List<Income>(currentFinance.Incomes.Concat(newIncomes))
			};

			var updatedFinance = _financeRepository.Update(financeToUpdate, id);
			if (updatedFinance is null)
			{
				return null;
			}

			return DtoMapper.FinanceToDto(updatedFinance);
		}

		public bool Remove(int id)
        {
            return _financeRepository.Remove(id);
        }
    }
}
