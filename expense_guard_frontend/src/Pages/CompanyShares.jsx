import React from "react";
import { useNavigate } from "react-router-dom";
import useFetchCompanyShares from "../Components/Hooks/useFetchCompanyShares";
import CompanySharesList from "../Components/Finance/CompanySharesList/CompanySharesList";
import paths from "../Shared/routes";

export default function CompanyShares() {
  // todo remove mocked data
  const response = useFetchCompanyShares();
  const navigate = useNavigate();

  if (response.error) {
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>CompanyShares</h1>
      <CompanySharesList companiesShares={response.data} />
    </div>
  );
}
