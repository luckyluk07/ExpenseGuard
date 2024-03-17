using ExpenseGuardBackend.DTOs.Finances;

namespace ExpenseGuardBackend.Services.Finances
{
    public interface IFinanceService
    {
        FinanceDto? GetFinance(int id);
        List<FinanceDto> GetFinances();
        bool Remove(int id);
    }
}