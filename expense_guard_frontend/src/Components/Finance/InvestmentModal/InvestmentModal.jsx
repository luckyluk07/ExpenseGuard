import React from "react";
import styles from "./InvestmentModal.module.scss";

const RESOURCE_INTEREST_RATE_TEXT = "Interest rate";
const RESOURCE_YEAR_TEXT = "year";
const RESOURCE_YEAR_CAPITALIZATION_AMOUNT_TEXT = "Year capitalization amount";
const RESOURCE_DESCRIPTION_AND_COMMENTS_TEXT = "Description and comments";

function InvestmentModal({ investment, onClose }) {
  return (
    // todo fix working on styles
    <div className={`${styles["modal-content"]} w-25 m-auto`}>
      <div className={styles["modal-header"]}>
        <h5 className={styles["modal-title"]}>{investment.name}</h5>
        <button
          onClick={onClose}
          type="button"
          className="btn-close"
          aria-label="Close"
        />
      </div>
      <div className={styles["modal-body"]}>
        <p>
          <span className={styles["investment-info"]}>
            {`${investment.startMoney.amount} ${investment.startMoney.currency}`}
          </span>
          <span className={styles["date-range"]}>
            {`${investment.startDate}-${investment.endDate}`}
          </span>
        </p>
        <p>
          <span className={styles["resource-label"]}>
            {RESOURCE_INTEREST_RATE_TEXT}:
          </span>
          <span className={styles["investment-info"]}>
            {investment.interestRate}
          </span>
        </p>
        <p>
          <span className={styles["resource-label"]}>
            {RESOURCE_YEAR_CAPITALIZATION_AMOUNT_TEXT}:
          </span>
          <span className={styles["investment-info"]}>
            {investment.yearCapitalizationAmount}
          </span>
          <span className={styles["investment-info"]}>
            {RESOURCE_YEAR_TEXT}
          </span>
        </p>
        <p>
          <span className={styles["resource-label"]}>
            {RESOURCE_DESCRIPTION_AND_COMMENTS_TEXT}:
          </span>
          <span className={styles["investment-info"]}>
            {investment.description}
          </span>
        </p>
      </div>
    </div>
  );
}

export default InvestmentModal;
