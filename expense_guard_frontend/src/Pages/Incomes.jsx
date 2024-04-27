import React from "react";
import IncomesGrid from "../Components/Finance/IncomesGrid/IncomesGrid";

export default function Incomes() {
  // todo remove mocked data
  const mockedIncomes = [
    {
      name: "Salary",
      category: "Income",
      money: 3000,
      receivedDate: "2024-04-01",
    },
    {
      name: "Freelance",
      category: "Income",
      money: 1500,
      receivedDate: "2024-04-15",
    },
    {
      name: "Bonus",
      category: "Extra Income",
      money: 500,
      receivedDate: "2024-04-25",
    },
  ];

  return (
    <div>
      <h1>Incomes</h1>
      <IncomesGrid incomes={mockedIncomes} />
    </div>
  );
}
