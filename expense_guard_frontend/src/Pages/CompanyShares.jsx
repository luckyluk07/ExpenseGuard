import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import useFetchCompanyShares from "../Components/Hooks/useFetchCompanyShares";
import CompanySharesList from "../Components/Finance/CompanyShares/CompanySharesList/CompanySharesList";
import paths from "../Shared/routes";
import NewCompanyShareForm from "../Components/Finance/CompanyShares/NewCompanyShareForm/NewCompanyShareForm";
import Button from "../Components/Common/Button/Button";

export default function CompanyShares() {
  const response = useFetchCompanyShares();
  const navigate = useNavigate();
  const [formVisibility, setFormVisibility] = useState(false);

  if (response.error) {
    navigate(paths.error);
    return null;
  }
  return (
    <div>
      <h1>CompanyShares</h1>
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
          <NewCompanyShareForm />
        </dev>
      )}
      <CompanySharesList companiesShares={response.data} />
    </div>
  );
}
