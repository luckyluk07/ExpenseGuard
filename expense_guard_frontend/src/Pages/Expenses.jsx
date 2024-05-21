import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import ExpenseList from "../Components/Finance/Expenses/ExpenseList/ExpenseList";
import useFetchExpenses from "../Components/Hooks/useFetchExpenses";
import paths from "../Shared/routes";
import NewExpenseForm from "../Components/Finance/Expenses/NewExpenseForm";
import Button from "../Components/Common/Button/Button";

export default function Expenses() {
  const response = useFetchExpenses();
  const navigate = useNavigate();
  const [formVisibility, setFormVisibility] = useState(false);
  const [data, setData] = useState();

  useEffect(() => {
    setData(response.data);
  }, [response]);

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
          <NewExpenseForm
            onDone={(element) => {
              const newElement = {
                id: element.id,
                name: element.name,
                spendDate: element.spendDate,
                price: element.money.amount,
                currencyId: element.money.currency.id,
                categoryId: element.category.id,
                financeId: 1,
              };
              setData((prevValue) => [...prevValue, newElement]);
            }}
          />
        </dev>
      )}
      <ExpenseList expenses={data} />
    </div>
  );
}
