using ExpenseGuardBackend.Mappers;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;
using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.CompanyShares;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.Incomes;
using ExpenseGuardBackend.Repositories.InvestmentDeposits;
using ExpenseGuardBackend.Services.Categories;
using ExpenseGuardBackend.Services.CompanyShares;
using ExpenseGuardBackend.Services.Currencies;
using ExpenseGuardBackend.Services.Expenses;
using ExpenseGuardBackend.Services.Finances;
using ExpenseGuardBackend.Services.Incomes;
using ExpenseGuardBackend.Services.InvestmentDeposits;
using ExpenseGuardBackend.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
					  });
});

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpenseGuardDbContext>(options =>
	options.UseInMemoryDatabase("InMemoryDatabase"));


// Data Access

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<IFinanceRepository, FinanceRepository>();
builder.Services.AddScoped<IInvestmentDepositRepository, InvestmentDepositRepository>();
builder.Services.AddScoped<ICompanyShareRepository, CompanyShareRepository>();

// Business
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();
builder.Services.AddScoped<IInvestmentDepositService, InvestmentDepositService>();
builder.Services.AddScoped<ICompanyShareService, CompanyShareService>();

// Shared
builder.Services.AddScoped<EntityMapper, EntityMapper>();

builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ExpenseGuardDbContext>();

var app = builder.Build();

// Seed the database with initial data
DataInitializer.SeedDatabase(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
