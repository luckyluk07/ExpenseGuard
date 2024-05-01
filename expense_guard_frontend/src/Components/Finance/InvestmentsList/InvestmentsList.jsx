import React from "react";
import InvestmentCard from "../InvestmentCard/InvestmentCard";
import NoDataAvailable from "../../../Pages/NoDataAvailable";

function InvestmentsList({ investments }) {
  return (
    <div>
      {!investments ? (
        <NoDataAvailable />
      ) : (
        investments.map((investment) => {
          return (
            <div>
              <InvestmentCard key={investment.name} investment={investment} />
            </div>
          );
        })
      )}
    </div>
  );
}

export default InvestmentsList;
