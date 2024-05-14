import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import ExpenseList from "../Components/Finance/Expenses/ExpenseList/ExpenseList";
import useFetchExpenses from "../Components/Hooks/useFetchExpenses";
import paths from "../Shared/routes";
import NewExpenseForm from "../Components/Finance/Expenses/NewExpenseForm/NewExpenseForm";
import Button from "../Components/Common/Button/Button";

export default function Expenses() {
  const response = useFetchExpenses();
  const navigate = useNavigate();
  const [formVisibility, setFormVisibility] = useState(false);

  if (response.error) {
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>Expenses</h1>
      {!formVisibility ? (
        <Button
          text="Display add form"
          onClick={() => setFormVisibility(true)}
        />
      ) : (
        <Button text="Hide add form" onClick={() => setFormVisibility(false)} />
      )}
      {formVisibility && (
        <dev>
          <NewExpenseForm />
        </dev>
      )}
      <ExpenseList expenses={response.data} />
    </div>
  );
}
