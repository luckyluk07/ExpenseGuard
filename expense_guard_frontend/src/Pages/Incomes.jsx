import React from "react";
import { useNavigate } from "react-router-dom";
import IncomesGrid from "../Components/Finance/IncomesGrid/IncomesGrid";
import useFetchIncomes from "../Components/Hooks/useFetchIncomes";
import paths from "../Shared/routes";

export default function Incomes() {
  // todo remove mocked data
  const response = useFetchIncomes();
  const navigate = useNavigate();

  if (response.error) {
    navigate(paths.error);
    return null;
  }

  return (
    <div>
      <h1>Incomes</h1>
      <IncomesGrid incomes={response.data} />
    </div>
  );
}
