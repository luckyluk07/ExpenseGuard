import React from "react";
import styles from "./CompanyShareBadge.module.scss";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";

const RESOURCE_AMOUNT_TEXT = "Amount";

function CompanyShareBadge({ id, name, money, amount, dateOfPurchase }) {
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
      <Button
        text="delete"
        onClick={() => deleteApiRequest(apiUrls.deleteCompanyShares(id))}
      />
    </div>
  );
}

export default CompanyShareBadge;
