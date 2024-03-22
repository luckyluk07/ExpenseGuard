using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Currencies;
using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Finances;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.DTOs.Money;
using ExpenseGuardBackend.Models;

namespace ExpenseGuardBackend.Shared
{
	public static class DtoMapper
	{
		public static FinanceDto FinanceToDto(Finance finance)
		{
			return new FinanceDto(finance.Id,
									finance.CurrencySavings.Select(x => MoneyToDto(x)).ToList(),
									finance.Incomes.Select(x => IncomeToDto(x)).ToList(),
									finance.Expenses.Select(x => ExpenseToDto(x)).ToList(),
									finance.Investments.Select(x => InvestmentDepositToDto(x)).ToList());
		}

		public static CurrencyDto CurrencyToDto(Currency currency)
		{
			return new CurrencyDto(currency.Id, currency.Name, currency.Code, currency.Country);
		}

		public static MoneyDto MoneyToDto(Money money)
		{
			return new MoneyDto(money.Amount, CurrencyToDto(money.Currency));
		}

		public static ExpenseDto ExpenseToDto(Expense expense)
		{
			var currencyDto = new CurrencyDto(expense.Money.Currency.Id, expense.Money.Currency.Name, expense.Money.Currency.Code, expense.Money.Currency.Country);
			var moneyDto = new MoneyDto(expense.Money.Amount, currencyDto);
			var categoryDto = new CategoryDto(expense.Category.Id, expense.Category.Name, expense.Category.Description);
			return new ExpenseDto(expense.Id, expense.Name, categoryDto, moneyDto, expense.SpendDate);
		}

		public static  IncomeDto IncomeToDto(Income income)
		{
			var currencyDto = new CurrencyDto(income.Money.Currency.Id, income.Money.Currency.Name, income.Money.Currency.Code, income.Money.Currency.Country);
			var moneyDto = new MoneyDto(income.Money.Amount, currencyDto);
			var categoryDto = new CategoryDto(income.Category.Id, income.Category.Name, income.Category.Description);
			return new IncomeDto(income.Id, income.Name, income.ReceivedDate, moneyDto, categoryDto);
		}

		public static CategoryDto CategoryToDto(Category category)
		{
			return new CategoryDto(category.Id, category.Name, category.Description);
		}

		public static InvestmentDepositDto InvestmentDepositToDto(InvestmentDeposit investmentDeposit)
		{
			return new InvestmentDepositDto(
					investmentDeposit.Id,
					investmentDeposit.Name,
					investmentDeposit.StartDate,
					investmentDeposit.EndDate,
					MoneyToDto(investmentDeposit.StartMoney),
					investmentDeposit.YearCapitalizationAmount,
					investmentDeposit.InterestRate
				);
		}
	}
}
