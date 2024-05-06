import React from "react";
import styles from "./CompanyShareBadge.module.scss";

const RESOURCE_AMOUNT_TEXT = "Amount";

function CompanyShareBadge({ name, money, amount, dateOfPurchase }) {
  return (
    <div
      className={`${styles.incomeBadgeContainerShape} ${styles.incomeBadgeContainerSkin} m-auto my-2`}
    >
      <h3>
        {name} {dateOfPurchase}
      </h3>
      <h4>
        {RESOURCE_AMOUNT_TEXT}: {amount}
      </h4>
      <h4>
        {money.amount} {money.currency.code}
      </h4>
    </div>
  );
}

export default CompanyShareBadge;
