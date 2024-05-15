import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import InvestmentsList from "../Components/Finance/Investments/InvestmentsList/InvestmentsList";
import useFetchInvestments from "../Components/Hooks/useFetchInvestments";
import paths from "../Shared/routes";
import NewInvestmentForm from "../Components/Finance/Investments/NewInvestmentForm/NewInvestmentForm";
import Button from "../Components/Common/Button/Button";

export default function Investments() {
  const response = useFetchInvestments();
  const navigate = useNavigate();
  const [formVisibility, setFormVisibility] = useState(false);

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
          <NewInvestmentForm />
        </dev>
      )}
      <div>
        <InvestmentsList investments={response.data} />
      </div>
    </div>
  );
}
