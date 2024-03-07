using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Models;
using ExpenseGuardBackend.Repositories;

namespace ExpenseGuardBackend.Services
{
	public class IncomeService : IIncomeService
	{
		private readonly IIncomeRepository _incomeRepository;

		public IncomeService(IIncomeRepository incomeRepository)
		{
			_incomeRepository = incomeRepository;
		}

		public List<IncomeDto> GetAll()
		{
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
				ReceivedDate = income.ReceivedDate
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
			return new IncomeDto(income.Id, income.Name, income.ReceivedDate, income.Amount);
		}
	}
}
