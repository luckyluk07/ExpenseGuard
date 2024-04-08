using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.CompanyShares;
using ExpenseGuardBackend.DTOs.Expense;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.DTOs.InvestmentDeposits;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Finances;

namespace ExpenseGuardBackend.Mappers
{
	public class EntityMapper
	{
		private readonly ICurrencyRepository _currencyRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IFinanceRepository _financeRepository;

		public EntityMapper(ICurrencyRepository currencyRepository, ICategoryRepository categoryRepository, IFinanceRepository financeRepository)
		{
			_currencyRepository = currencyRepository;
			_categoryRepository = categoryRepository;
			_financeRepository = financeRepository;
		}

		public Income CreateIncomeDtoToIncome(CreateIncomeDto createIncomeDto)
		{
			var currency = _currencyRepository.Get(createIncomeDto.CurrencyId);
			var category = _categoryRepository.Get(createIncomeDto.CategoryId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}
			else if (category is null)
			{
				throw new ArgumentNullException(nameof(category));
			}

			return new Income()
			{
				Money = new Money()
				{
					Amount = createIncomeDto.Amount,
					Currency = currency
				},
				Name = createIncomeDto.Name,
				ReceivedDate = createIncomeDto.ReceivedDate,
				Category = category
			};
		}

		public Income UpdateIncomeDtoToIncome(UpdateIncomeDto updateIncomeDto)
		{
			var currency = _currencyRepository.Get(updateIncomeDto.CurrencyId);
			var category = _categoryRepository.Get(updateIncomeDto.CategoryId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}
			else if (category is null)
			{
				throw new ArgumentNullException(nameof(category));
			}

			return new Income()
			{
				Money = new Money()
				{
					Amount = updateIncomeDto.Amount,
					Currency = currency
				},
				ReceivedDate = updateIncomeDto.ReceivedDate,
				Category = category
			};
		}

		public Expense CreateExpenseDtoToExpense(CreateExpenseDto createExpenseDto)
		{
			var currency = _currencyRepository.Get(createExpenseDto.CurrencyId);
			var category = _categoryRepository.Get(createExpenseDto.CategoryId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}
			else if (category is null)
			{
				throw new ArgumentNullException(nameof(category));
			}

			return new Expense()
			{
				Name = createExpenseDto.Name,
				Category = category,
				Money = new Money()
				{
					Amount = createExpenseDto.Price,
					Currency = currency
				},
				SpendDate = createExpenseDto.SpendDate,
			};
		}

		public Expense UpdateExpenseDtoToExpense(UpdateExpenseDto updateExpenseDto)
		{
			var currency = _currencyRepository.Get(updateExpenseDto.CurrencyId);
			var category = _categoryRepository.Get(updateExpenseDto.CategoryId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}
			else if (category is null)
			{
				throw new ArgumentNullException(nameof(category));
			}

			return new Expense()
			{
				Category = category,
				Money = new Money()
				{
					Amount = updateExpenseDto.Price,
					Currency = currency
				},
				SpendDate = updateExpenseDto.SpendDate,
			};
		}

		public Category CreateCategoryDtoToCategory(CreateCategoryDto createCategoryDto)
		{
			return new Category()
			{
				Name = createCategoryDto.Name,
				Description = createCategoryDto.Description
			};
		}

		public Category UpdateCategoryDtoToCategory(UpdateCategoryDto updateCategiryDto)
		{
			return new Category()
			{
				Name = updateCategiryDto.Name,
				Description = updateCategiryDto.Description
			};
		}

		public InvestmentDeposit CreateInvestmentDepositDtoToInvestmentDeposit(CreateInvestmentDepositDto createInvestmentDepositDto)
		{
			var currency = _currencyRepository.Get(createInvestmentDepositDto.StartMoney.CurrencyId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}

			return new InvestmentDeposit()
			{
				YearCapitalizationAmount = createInvestmentDepositDto.YearCapitalizationAmount,
				EndDate = createInvestmentDepositDto.EndDate,
				InterestRate = createInvestmentDepositDto.InterestRate,
				Name = createInvestmentDepositDto.Name,
				StartDate = createInvestmentDepositDto.StartDate,
				StartMoney = new Money()
				{
					Amount = createInvestmentDepositDto.StartMoney.Amount,
					Currency = currency
				}
			};
		}

		public CompanyShare CreateCompanyShareDtoToCompanyShare(CreateCompanyShareDto createCompanyShareDto)
		{
			var currency = _currencyRepository.Get(createCompanyShareDto.CurrencyId);
			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}

			var finance = _financeRepository.Get(createCompanyShareDto.FinanceId);
			if (finance is null)
			{
				throw new ArgumentNullException(nameof(finance));
			}

			return new CompanyShare()
			{
				Name = createCompanyShareDto.Name,
				Amount = createCompanyShareDto.SharesAmount,
				DateOfPurchase = createCompanyShareDto.DateOfPurchase,
				Price = new Money()
				{
					Amount = createCompanyShareDto.Price,
					Currency = currency
				}, 
				Finance = finance
			};
		}

		public CompanyShare UpdateCompanyShareDtoToCompanyShare(UpdateCompanyShareDto updateCompanyShareDto)
		{
			var currency = _currencyRepository.Get(updateCompanyShareDto.CurrencyId);

			if (currency is null)
			{
				throw new ArgumentNullException(nameof(currency));
			}

			return new CompanyShare()
			{
				Name = updateCompanyShareDto.Name,
				Amount = updateCompanyShareDto.SharesAmount,
				DateOfPurchase = updateCompanyShareDto.DateOfPurchase,
				Price = new Money()
				{
					Amount = updateCompanyShareDto.Price,
					Currency = currency
				}
			};
		}
	}
}
