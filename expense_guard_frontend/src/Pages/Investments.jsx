import React from "react";
import { useNavigate } from "react-router-dom";
import InvestmentsList from "../Components/Finance/InvestmentsList/InvestmentsList";
import useFetchInvestments from "../Components/Hooks/useFetchInvestments";
import paths from "../Shared/routes";

export default function Investments() {
  // todo list of some badges/news with button to open modal with details
  const response = useFetchInvestments();
  const navigate = useNavigate();

  if (response.error) {
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>Investments</h1>
      <div>
        <InvestmentsList investments={response.data} />
      </div>
    </div>
  );
}
