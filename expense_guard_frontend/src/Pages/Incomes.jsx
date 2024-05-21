import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import IncomesGrid from "../Components/Finance/Incomes/IncomesGrid/IncomesGrid";
import useFetchIncomes from "../Components/Hooks/useFetchIncomes";
import paths from "../Shared/routes";
import NewIncomeForm from "../Components/Finance/Incomes/NewIncomeForm";
import Button from "../Components/Common/Button/Button";

export default function Incomes() {
  const response = useFetchIncomes();
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
          <NewIncomeForm
            onDone={(element) => {
              const newElement = {
                name: element.name,
                receivedDate: element.date,
                amount: element.amount,
                currencyId: element.currencyId,
                categoryId: element.categoryId,
                financeId: 1,
              };
              setData((prevValue) => [...prevValue, newElement]);
            }}
          />
        </dev>
      )}
      <IncomesGrid incomes={data} />
    </div>
  );
}
