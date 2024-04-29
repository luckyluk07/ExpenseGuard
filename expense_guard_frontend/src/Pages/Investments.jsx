import React from "react";
import InvestmentCard from "../Components/Finance/InvestmentCard/InvestmentCard";

export default function Investments() {
  // todo list of some badges/news with button to open modal with details
  const mockedInvestments = [
    {
      name: "Investment 1",
      startDate: "2023-01-01",
      endDate: "2023-12-31",
      startMoney: {
        amount: 10000,
        currency: "USD",
      },
      interestRate: 5,
      yearCapitalizationAmount: 500,
    },
    // {
    //   name: "Investment 2",
    //   startDate: "2022-06-15",
    //   endDate: "2024-06-15",
    //   startMoney: {
    //     amount: 15000,
    //     currency: "EUR",
    //   },
    //   interestRate: 7,
    //   yearCapitalizationAmount: 750,
    // },
  ];
  return (
    <div>
      <h1>Investments</h1>
      <div>
        {mockedInvestments.map((investment) => {
          return (
            <div>
              <InvestmentCard key={investment.name} investment={investment} />
            </div>
          );
        })}
      </div>
    </div>
  );
}
