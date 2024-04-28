import React from "react";
import ExpenseList from "../Components/Finance/ExpenseList/ExpenseList";

export default function Expenses() {
  const mockedExpenses = [
    {
      name: "Groceries",
      description: "Weekly grocery shopping",
      money: {
        amount: 50,
        currency: {
          code: "USD",
        },
      },
    },
    {
      name: "Utilities",
      description: "Electricity bill",
      money: {
        amount: 100,
        currency: {
          code: "USD",
        },
      },
    },
    {
      name: "Rent",
      description: "Monthly rent payment",
      money: {
        amount: 1200,
        currency: {
          code: "USD",
        },
      },
    },
    // Add more expenses as needed
  ];
  return (
    <div>
      <h1>Expenses</h1>
      <ExpenseList expenses={mockedExpenses} />
    </div>
  );
}
