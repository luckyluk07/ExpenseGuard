import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import IncomesGrid from "../Components/Finance/Incomes/IncomesGrid/IncomesGrid";
import useFetchIncomes from "../Components/Hooks/useFetchIncomes";
import paths from "../Shared/routes";
import NewIncomeForm from "../Components/Finance/Incomes/NewIncomeForm/NewIncomeForm";
import Button from "../Components/Common/Button/Button";

export default function Incomes() {
  const response = useFetchIncomes();
  const navigate = useNavigate();
  const [formVisibility, setFormVisibility] = useState(false);

  if (response.error) {
    navigate(paths.error);
    return null;
  }

  return (
    <div>
      <h1>Incomes</h1>
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
          <NewIncomeForm />
        </dev>
      )}
      <IncomesGrid incomes={response.data} />
    </div>
  );
}
