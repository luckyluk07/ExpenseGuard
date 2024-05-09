const base = "https://localhost:7057/api";

const apiUrls = {
  getCategories: `${base}/Category`,
  getCurrencies: `${base}/Currency`,
  getIncomes: `${base}/Income`,
  getExpenses: `${base}/Expense`,
  getCompanyShares: `${base}/CompanyShare`,
  getInvestmentsDeposits: `${base}/InvestmentDeposit`,

  postIncome: `${base}/Income`,

  deleteIncome: `${base}/Income`,
};

export default apiUrls;
