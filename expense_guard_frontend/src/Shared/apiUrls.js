const base = "https://localhost:7057/api";

const apiUrls = {
  getCategories: `${base}/Category`,
  getCurrencies: `${base}/Currency`,
  getIncomes: `${base}/Income`,
  getExpenses: `${base}/Expense`,
  getCompanyShares: `${base}/CompanyShare`,
  getInvestmentsDeposits: `${base}/InvestmentDeposit`,

  postIncome: `${base}/Income`,
  postExpense: `${base}/Expense`,
  postInvestment: `${base}/InvestmentDeposit`,
  postCompanyShares: `${base}/CompanyShare`,

  deleteIncome: `${base}/Income`,
};

export default apiUrls;
