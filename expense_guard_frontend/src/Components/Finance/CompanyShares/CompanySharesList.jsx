import React from "react";
import NoDataAvailable from "../../../Pages/NoDataAvailable";
import CompanyShareBadge from "./CompanyShareBadge/CompanyShareBadge";

function CompanySharesList({ companiesShares }) {
  return (
    <div>
      {!companiesShares || companiesShares.length === 0 ? (
        <NoDataAvailable />
      ) : (
        companiesShares.map((companyShare) => {
          return (
            <CompanyShareBadge
              id={companyShare.id}
              name={companyShare.name}
              money={companyShare.money}
              amount={companyShare.amount}
              dateOfPurchase={companyShare.dateOfPurchase}
            />
          );
        })
      )}
    </div>
  );
}

export default CompanySharesList;
