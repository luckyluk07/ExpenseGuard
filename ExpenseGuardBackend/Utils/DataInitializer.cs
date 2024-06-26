﻿using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;

namespace ExpenseGuardBackend.Utils
{
	public static class DataInitializer
	{
		public static void SeedDatabase(IServiceProvider serviceProvider)
		{
			using (var scope = serviceProvider.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<ExpenseGuardDbContext>();

					context.Currencies.AddRange(
						new Currency { Id = 1, Name = "Zloty", Code = "PLN", Country = "Poland" },
						new Currency { Id = 2, Name = "Dollar", Code = "USD", Country = "USA" }
					);

					context.Money.AddRange(
						new Money { Id = 1, Amount = 10, CurrencyId = 1 },
						new Money { Id = 2, Amount = 20, CurrencyId = 1 },
						new Money { Id = 3, Amount = 50, CurrencyId = 1 },
						new Money { Id = 4, Amount = 1000, CurrencyId = 1 },
						new Money { Id = 5, Amount = 1234, CurrencyId = 1 },
						new Money { Id = 6, Amount = 1000, CurrencyId = 2}
					);

					context.Categories.AddRange(
						new Category { Name = "Food", Description = "Ingredients for daily meals" },
						new Category { Name = "Restaurants", Description = "Cost of going out to the restaurants" }
					);

					context.Finances.Add(
						new Finance { Id = 1, Incomes = new List<Income>(), Expenses = new List<Expense>(), Investments = new List<InvestmentDeposit>(), CurrencySavings = new List<Money>(), CompanyShares = new List<CompanyShare>() }
					);

					context.Incomes.Add(
						new Income { CategoryId = 1, FinanceId = 1, MoneyId = 4, Name = "Sold Pizza", ReceivedDate = DateTime.Now }
					);

					context.Expenses.Add(
						new Expense { CategoryId = 1, FinanceId = 1, MoneyId = 1, Name = "Pizza ingredients", SpendDate = DateTime.Now }
					);

					context.InvestmentsDeposits.Add(
						new InvestmentDeposit { EndDate = DateTime.Now, FinanceId = 1, InterestRate = 3, Name = "Oszczednosciowe PKO", StartDate = DateTime.Now.AddDays(180), StartMoneyId = 5, YearCapitalizationAmount = 2 }
					);

					context.CompanyShares.Add(
						new CompanyShare { 
							FinanceId = 1,
							DateOfPurchase= DateTime.Now,
							Amount = 1000,
							Name = "S&P 500",
							PriceId = 6 }
						);

					context.SaveChanges();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
				}
			}
		}
		}
}
