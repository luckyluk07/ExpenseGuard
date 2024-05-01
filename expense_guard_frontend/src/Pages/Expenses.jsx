import React from "react";
import { useNavigate } from "react-router-dom";
import ExpenseList from "../Components/Finance/ExpenseList/ExpenseList";
import useFetchExpenses from "../Components/Hooks/useFetchExpenses";

export default function Expenses() {
  const response = useFetchExpenses();
  const navigate = useNavigate();

  if (response.error) {
    navigate("/Error");
    return null;
  }
  return (
    <div>
      <h1>Expenses</h1>
      <ExpenseList expenses={response.data} />
    </div>
  );
}
