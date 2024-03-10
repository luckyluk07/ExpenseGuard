using ExpenseGuardBackend.DTOs.Categories;
using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;
using ExpenseGuardBackend.Repositories.Categories;

namespace ExpenseGuardBackend.Services
{
	public class IncomeService : IIncomeService
	{
		private readonly IIncomeRepository _incomeRepository;
		private readonly ICategoryRepository _categoryRepository;

		public IncomeService(IIncomeRepository incomeRepository, ICategoryRepository categoryRepository)
		{
			_incomeRepository = incomeRepository;
			_categoryRepository = categoryRepository;
		}

		public List<IncomeDto> GetAll()
		{
			var allIncomes = _incomeRepository.GetAll();
			return _incomeRepository.GetAll()
				.Select(IncomeToDto)
				.ToList();
		}

		public IncomeDto? Get(int id)
		{
			var income = _incomeRepository.Get(id);
			if (income is null)
			{
				return null;
			}
			return IncomeToDto(income);
		}

		public IncomeDto Create(CreateIncomeDto income)
		{
			var incomeToCreate = new Income()
			{
				Amount = income.Amount,
				Name = income.Name,
				ReceivedDate = income.ReceivedDate,
				Category = _categoryRepository.Get(income.CategoryId)
			};

			var createdIncome = _incomeRepository.Create(incomeToCreate);
			return IncomeToDto(createdIncome);
		}

		public bool Delete(int id)
		{
			return _incomeRepository.Delete(id);
		}

		public IncomeDto? Update(UpdateIncomeDto income, int id)
		{
			var incomeToUpdate = new Income()
			{
				Amount = income.Amount,
				ReceivedDate = income.ReceivedDate, 
				Category = _categoryRepository.Get(income.CategoryId)
			};
			var updatedIncome = _incomeRepository.Update(incomeToUpdate, id);
			if (updatedIncome is null)
			{
				return null;
			}
			return IncomeToDto(updatedIncome);
		}

		private IncomeDto IncomeToDto(Income income)
		{
			var categoryDto = new CategoryDto(income.Category.Id, income.Category.Name, income.Category.Description);
			return new IncomeDto(income.Id, income.Name, income.ReceivedDate, income.Amount, categoryDto);
		}
	}
}
