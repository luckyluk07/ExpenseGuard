﻿using ExpenseGuardBackend.DTOs.Finances;

namespace ExpenseGuardBackend.Services.Finances
{
    public interface IFinanceService
    {
        FinanceDto? GetFinance(int id);
        List<FinanceDto> GetFinances();
        FinanceDto Create(CreateFinanceDto createFinanceDto);
        FinanceDto? Update(UpdateFinanceDto finance, int id);
		bool Remove(int id);
    }
}