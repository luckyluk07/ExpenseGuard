import React from "react";
import { useNavigate } from "react-router-dom";
import useFetchCompanyShares from "../Components/Hooks/useFetchCompanyShares";
import CompanySharesList from "../Components/Finance/CompanyShares/CompanySharesList/CompanySharesList";
import paths from "../Shared/routes";
import NewCompanyShareForm from "../Components/Finance/CompanyShares/NewCompanyShareForm/NewCompanyShareForm";

export default function CompanyShares() {
  // todo remove mocked data
  // todo fix fetching data - error on backend site
  const response = useFetchCompanyShares();
  const navigate = useNavigate();

  if (response.error) {
    alert(response.error);
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>CompanyShares</h1>
      <NewCompanyShareForm />
      <CompanySharesList companiesShares={response.data} />
    </div>
  );
}
