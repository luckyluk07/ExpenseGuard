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

		public List<Income> GetAll()
		{
			return _incomeRepository.GetAll();
		}

		public Income? Get(int id)
		{
			return _incomeRepository.Get(id);
		}

		public Income Create(Income income)
		{
			return _incomeRepository.Create(income);
		}

		public bool Delete(int id)
		{
			return _incomeRepository.Delete(id);
		}

		public Income? Update(Income income, int id)
		{
			return _incomeRepository.Update(income, id);
		}
	}
}
