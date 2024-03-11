using ExpenseGuardBackend.DTOs.Income;

namespace ExpenseGuardBackend.Services.Incomes
{
    public interface IIncomeService
    {
        IncomeDto Create(CreateIncomeDto income);
        bool Delete(int id);
        IncomeDto? Get(int id);
        List<IncomeDto> GetAll();
        IncomeDto? Update(UpdateIncomeDto income, int id);
    }
}