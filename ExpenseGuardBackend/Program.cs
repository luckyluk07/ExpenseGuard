using ExpenseGuardBackend.Mappers;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.Incomes;
using ExpenseGuardBackend.Repositories.InvestmentDeposits;
using ExpenseGuardBackend.Services.Categories;
using ExpenseGuardBackend.Services.Currencies;
using ExpenseGuardBackend.Services.Expenses;
using ExpenseGuardBackend.Services.Finances;
using ExpenseGuardBackend.Services.Incomes;
using ExpenseGuardBackend.Services.InvestmentDeposits;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpenseGuardDbContext>(options =>
	options.UseInMemoryDatabase("InMemoryDatabase"));


// Data Access
// todo remove legacy repositories
//builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();
//builder.Services.AddSingleton<IIncomeRepository, IncomeRepository>();
//builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
//builder.Services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
//builder.Services.AddSingleton<IFinanceRepository, FinanceRepository>();
//builder.Services.AddSingleton<IInvestmentDepositRepository, InvestmentDepositRepository>();

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository2>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository2>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository2>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository2>();
builder.Services.AddScoped<IFinanceRepository, FinanceRepository2>();
builder.Services.AddScoped<IInvestmentDepositRepository, InvestmentDepositRepository2>();

// Business
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();
builder.Services.AddScoped<IInvestmentDepositService, InvestmentDepositService>();

// Shared
builder.Services.AddScoped<EntityMapper, EntityMapper>();

var app = builder.Build();

// Seed the database with initial data
SeedDatabase(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void SeedDatabase(IServiceProvider serviceProvider)
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
				new Money { Id = 4, Amount = 1000, CurrencyId = 1 }
			);

			context.Categories.AddRange(
				new Category { Name = "Food", Description = "Ingredients for daily meals" },
				new Category { Name = "Restaurants", Description = "Cost of going out to the restaurants" }
			);

			context.Finances.Add(
				new Finance { Id = 1, Incomes = new List<Income>(), Expenses = new List<Expense>(), Investments = new List<InvestmentDeposit>(), CurrencySavings = new List<Money>() }
			);

			context.Incomes.Add(
				new Income { CategoryId = 1, FinanceId = 1, MoneyId = 4, Name = "Sold Pizza", ReceivedDate = new DateTime() }
			);

			context.Expenses.Add(
				new Expense { CategoryId = 1, FinanceId = 1, MoneyId = 1, Name = "Pizza ingredients", SpendDate = new DateTime() }
			);

			context.SaveChanges();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
		}
	}
}
