/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
import React from "react";
import styles from "../../styles/Modal.module.scss";
import Button from "../../Common/Button/Button";
import deleteApiRequest from "../../Services/Api/deleteApiRequest";
import apiUrls from "../../../Shared/apiUrls";
import { toGermanFormat } from "../../Services/General/DateFormatter";

const RESOURCE_INTEREST_RATE_TEXT = "Interest rate";
const RESOURCE_YEAR_TEXT = "year";
const RESOURCE_YEAR_CAPITALIZATION_AMOUNT_TEXT = "Year capitalization amount";
const RESOURCE_DESCRIPTION_AND_COMMENTS_TEXT = "Description and comments";

function InvestmentModal({ investment, onClose }) {
  return (
    <div
      className={styles["overlay-styles"]}
      onClick={(event) => {
        onClose();
        event.stopPropagation();
      }}
    >
      <div
        className={`${styles["modal-content"]} w-25 m-auto`}
        onClick={(event) => {
          event.stopPropagation();
        }}
      >
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
              {`${toGermanFormat(investment.startDate)}-${toGermanFormat(investment.endDate)}`}
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
          <div>
            <Button
              text="Delete"
              onClick={() =>
                deleteApiRequest(apiUrls.deleteInvestment(investment.id))
              }
            />
          </div>
        </div>
      </div>
    </div>
  );
}

export default InvestmentModal;
