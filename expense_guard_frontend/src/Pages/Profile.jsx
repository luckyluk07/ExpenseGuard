import React from "react";
import { useNavigate } from "react-router-dom";
import useFetchCompanyShares from "../Components/Hooks/useFetchCompanyShares";
import useFetchInvestments from "../Components/Hooks/useFetchInvestments";
import useFetchExpenses from "../Components/Hooks/useFetchExpenses";
import useFetchIncomes from "../Components/Hooks/useFetchIncomes";
import Button from "../Components/Common/Button/Button";
import paths from "../Shared/routes";

export default function Profile() {
  const investmentsResponse = useFetchInvestments();
  const expensesResponse = useFetchExpenses();
  const companySharesResponse = useFetchCompanyShares();
  const incomesResponse = useFetchIncomes();
  const navigate = useNavigate();

  if (
    investmentsResponse.error ||
    expensesResponse.error ||
    companySharesResponse.error ||
    incomesResponse.error
  ) {
    navigate(paths.error);
    return null;
  }

  return (
    <div>
      <h1>Profile</h1>
      <div style={{ display: "flex" }}>
        {/* Iterate over each response and render a column */}
        {[
          {
            title: "Investments",
            data: investmentsResponse.data,
            link: paths.investments,
          },
          {
            title: "Expenses",
            data: expensesResponse.data,
            link: paths.expenses,
          },
          {
            title: "Company Shares",
            data: companySharesResponse.data,
            link: paths.companyShares,
          },
          {
            title: "Incomes",
            data: incomesResponse.data,
            link: paths.incomes,
          },
        ].map(({ title, data, link }) => (
          <div key={title} style={{ flex: 1, margin: "0 10px" }}>
            <h2>{title}</h2>
            {data &&
              data.map((item) => (
                <div key={item.name}>
                  <p>{item.name}</p>
                </div>
              ))}
            <Button text="Go to main page" onClick={() => navigate(link)} />
          </div>
        ))}
      </div>
    </div>
  );
}
