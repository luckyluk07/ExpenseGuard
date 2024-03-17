using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.Money;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Finances;

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
                .Select(FinanceToDto)
                .ToList();
        }

        public FinanceDto? GetFinance(int id)
        {
            var finance = _financeRepository.Get(id);
            if (finance is null)
            {
                return null;
            }

            return FinanceToDto(finance);
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

        //todo remove duplicated methods - create mapper class or use autoMapper
        private FinanceDto FinanceToDto(Finance finance)
        {
            return new FinanceDto(finance.CurrencySavings.Select(x => MoneyToDto(x)).ToList(),
                                            finance.Incomes.Select(x => IncomeToDto(x)).ToList(),
                                            finance.Expenses.Select(x => ExpenseToDto(x)).ToList());
        }

        private CurrencyDto CurrencyToDto(Currency currency)
        {
            return new CurrencyDto(currency.Id, currency.Name, currency.Code, currency.Country);
        }

        private MoneyDto MoneyToDto(Money money)
        {
            return new MoneyDto(money.Amount, CurrencyToDto(money.Currency));
        }

        private ExpenseDto ExpenseToDto(Expense expense)
        {
            var currencyDto = new CurrencyDto(expense.Money.Currency.Id, expense.Money.Currency.Name, expense.Money.Currency.Code, expense.Money.Currency.Country);
            var moneyDto = new MoneyDto(expense.Money.Amount, currencyDto);
            var categoryDto = new CategoryDto(expense.Category.Id, expense.Category.Name, expense.Category.Description);
            return new ExpenseDto(expense.Id, expense.Name, categoryDto, moneyDto, expense.SpendDate);
        }

        private IncomeDto IncomeToDto(Income income)
        {
            var currencyDto = new CurrencyDto(income.Money.Currency.Id, income.Money.Currency.Name, income.Money.Currency.Code, income.Money.Currency.Country);
            var moneyDto = new MoneyDto(income.Money.Amount, currencyDto);
            var categoryDto = new CategoryDto(income.Category.Id, income.Category.Name, income.Category.Description);
            return new IncomeDto(income.Id, income.Name, income.ReceivedDate, moneyDto, categoryDto);
        }
    }
}
