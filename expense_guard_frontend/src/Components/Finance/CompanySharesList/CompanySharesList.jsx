import React from "react";
import NoDataAvailable from "../../../Pages/NoDataAvailable";
import CompanyShareBadge from "../CompanyShareBadge/CompanyShareBadge";

function CompanySharesList({ companiesShares }) {
  return (
    <div>
      {!companiesShares ? (
        <NoDataAvailable />
      ) : (
        companiesShares.map((companyShare) => {
          return (
            <CompanyShareBadge
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
