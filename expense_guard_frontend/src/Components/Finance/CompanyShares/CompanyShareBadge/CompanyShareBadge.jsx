import React, { useState } from "react";
import { createPortal } from "react-dom";
import styles from "./CompanyShareBadge.module.scss";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";
import UpdateCompanyShareModal from "../UpdateCompanyShareModal";
import { toGermanFormat } from "../../../Services/General/DateFormatter";

const RESOURCE_AMOUNT_TEXT = "Amount";

function CompanyShareBadge({ id, name, money, amount, dateOfPurchase }) {
  const [showModal, setShowModal] = useState(false);
  return (
    <div>
      <div
        className={`${styles.incomeBadgeContainerShape} ${styles.incomeBadgeContainerSkin} m-auto my-2`}
      >
        <h3>
          {name} {toGermanFormat(dateOfPurchase)}
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
        <Button text="update" onClick={() => setShowModal(true)} />
      </div>
      {showModal &&
        createPortal(
          <UpdateCompanyShareModal
            id={id}
            shareName={name}
            shareAmount={amount}
            sharePrice={money.amount}
            shareCurrency={money.currency.id}
            shareDate={dateOfPurchase}
            onClose={() => setShowModal(false)}
          />,
          document.getElementById("portal"),
        )}
    </div>
  );
}

export default CompanyShareBadge;
