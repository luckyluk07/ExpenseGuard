using ExpenseGuardBackend.Mappers;
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
builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();
builder.Services.AddSingleton<IIncomeRepository, IncomeRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddSingleton<IFinanceRepository, FinanceRepository>();
builder.Services.AddSingleton<IInvestmentDepositRepository, InvestmentDepositRepository>();

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
