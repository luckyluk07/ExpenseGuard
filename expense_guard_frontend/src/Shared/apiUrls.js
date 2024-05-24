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
  postCategory: `${base}/Category`,

  updateIncome: (id) => `${base}/Income/${id}`,
  updateExpense: (id) => `${base}/Expense/${id}`,
  updateInvestment: (id) => `${base}/InvestmentDeposit/${id}`,
  updateCompanyShares: (id) => `${base}/CompanyShare/${id}`,

  deleteIncome: (id) => `${base}/Income/${id}`,
  deleteExpense: (id) => `${base}/Expense/${id}`,
  deleteInvestment: (id) => `${base}/InvestmentDeposit/${id}`,
  deleteCompanyShares: (id) => `${base}/CompanyShare/${id}`,
};

export default apiUrls;
