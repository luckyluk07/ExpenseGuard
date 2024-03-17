using ExpenseGuardBackend.Repositories.Categories;
using ExpenseGuardBackend.Repositories.Currencies;
using ExpenseGuardBackend.Repositories.Expenses;
using ExpenseGuardBackend.Repositories.Finances;
using ExpenseGuardBackend.Repositories.Incomes;
using ExpenseGuardBackend.Services.Categories;
using ExpenseGuardBackend.Services.Currencies;
using ExpenseGuardBackend.Services.Expenses;
using ExpenseGuardBackend.Services.Finances;
using ExpenseGuardBackend.Services.Incomes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Access
builder.Services.AddSingleton<IExpenseRepository,  ExpenseRepository>();
builder.Services.AddSingleton<IIncomeRepository, IncomeRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddSingleton<IFinanceRepository, FinanceRepository>();

// Business
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICurrencyService,  CurrencyService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();

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
