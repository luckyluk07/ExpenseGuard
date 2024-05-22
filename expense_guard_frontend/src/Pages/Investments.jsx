import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import InvestmentsList from "../Components/Finance/Investments/InvestmentsList";
import useFetchInvestments from "../Components/Hooks/useFetchInvestments";
import paths from "../Shared/routes";
import NewInvestmentForm from "../Components/Finance/Investments/NewInvestmentForm";
import Button from "../Components/Common/Button/Button";

export default function Investments() {
  const response = useFetchInvestments();
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
      <h1>Investments</h1>
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
          <NewInvestmentForm
            onDone={(element) => {
              const newElement = {
                name: element.name,
                startDate: element.startDate,
                endDate: element.endDate,
                startMoney: {
                  amount: element.startMoney.amount,
                  currencyId: element.startMoney.currency.id,
                },
                interestRate: element.interestRate,
                yearCapitalizationAmount: element.yearCapitalizationAmount,
                financeId: 1,
              };
              setData((prevValue) => [...prevValue, newElement]);
            }}
          />
        </dev>
      )}
      <div>
        <InvestmentsList investments={data} />
      </div>
    </div>
  );
}
