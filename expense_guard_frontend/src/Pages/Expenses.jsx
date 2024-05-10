import React from "react";
import { useNavigate } from "react-router-dom";
import ExpenseList from "../Components/Finance/Expenses/ExpenseList/ExpenseList";
import useFetchExpenses from "../Components/Hooks/useFetchExpenses";
import paths from "../Shared/routes";
import NewExpenseForm from "../Components/Finance/Expenses/NewExpenseForm/NewExpenseForm";

export default function Expenses() {
  const response = useFetchExpenses();
  const navigate = useNavigate();

  if (response.error) {
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>Expenses</h1>
      <NewExpenseForm />
      <ExpenseList expenses={response.data} />
    </div>
  );
}
