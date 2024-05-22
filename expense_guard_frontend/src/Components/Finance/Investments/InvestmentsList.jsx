import React from "react";
import InvestmentCard from "./InvestmentCard/InvestmentCard";
import NoDataAvailable from "../../../Pages/NoDataAvailable";

function InvestmentsList({ investments }) {
  return (
    <div>
      {!investments || investments.length === 0 ? (
        <NoDataAvailable />
      ) : (
        investments.map((investment) => {
          return (
            <div key={investment.name}>
              <InvestmentCard investment={investment} />
            </div>
          );
        })
      )}
    </div>
  );
}

export default InvestmentsList;
