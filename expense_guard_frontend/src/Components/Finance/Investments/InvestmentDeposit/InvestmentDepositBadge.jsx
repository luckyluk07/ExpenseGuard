import React from "react";
import styles from "./InvestmentDepositBadge.module.scss";

function InvestmentDepositBadge({
  name,
  startDate,
  endDate,
  startMoney,
  yearCapitalizationAmount,
  interestRate,
}) {
  return (
    <div
      className={`${styles.containerSkinInvestment} ${styles.containerShapeInvestment}`}
    >
      <h3>{name}</h3>
      <h4>
        Date range: {startDate} - {endDate}
      </h4>
      <h4>
        {startMoney.amount} {startMoney.currency.code}
      </h4>
      <p>
        Year capitalization: {yearCapitalizationAmount}, with year interest rate
        of {interestRate}
      </p>
    </div>
  );
}

export default InvestmentDepositBadge;
