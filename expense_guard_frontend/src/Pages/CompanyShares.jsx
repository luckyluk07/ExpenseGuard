import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import useFetchCompanyShares from "../Components/Hooks/useFetchCompanyShares";
import CompanySharesList from "../Components/Finance/CompanyShares/CompanySharesList";
import paths from "../Shared/routes";
import NewCompanyShareForm from "../Components/Finance/CompanyShares/NewCompanyShareForm";
import Button from "../Components/Common/Button/Button";

export default function CompanyShares() {
  const response = useFetchCompanyShares();
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
          <NewCompanyShareForm
            onDone={(element) => {
              const newObject = {
                id: element.id,
                name: element.name,
                dateOfPurchase: element.dateOfPurchase,
                amount: element.amount,
                price: {
                  money: {
                    amount: element.price.amount,
                    currency: element.price.currency,
                  },
                },
              };
              setData((prevData) => [...prevData, newObject]);
            }}
          />
        </dev>
      )}
      <CompanySharesList companiesShares={data} />
    </div>
  );
}
