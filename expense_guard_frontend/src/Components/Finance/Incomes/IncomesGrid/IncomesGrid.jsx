import React from "react";
import styles from "./IncomesGrid.module.scss";
import NoDataAvailable from "../../../../Pages/NoDataAvailable";
import Button from "../../../Common/Button/Button";

const RESOURCE_NUMBER = "Number";
const RESOURCE_NAME = "Name";
const RESOURCE_CATEGORY = "Category";
const RESOURCE_MONEY = "Money";
const RESOURCE_RECEIVED = "Received";
const RESOURCE_UPDATE = "Update";

function IncomesGrid({ incomes }) {
  return (
    <div className={`container ${styles.gridSkin}`}>
      <div className="row">
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_NUMBER}
        </div>
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_NAME}
        </div>
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_CATEGORY}
        </div>
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_MONEY}
        </div>
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_RECEIVED}
        </div>
        <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
          {RESOURCE_UPDATE}
        </div>
      </div>
      {!incomes || incomes.length === 0 ? (
        <NoDataAvailable />
      ) : (
        incomes.map((income, index) => {
          return (
            <div className="row" key={income.name}>
              <div className={`col ${styles.gridItem}`}>{index + 1}</div>
              <div className={`col ${styles.gridItem}`}>{income.name}</div>
              <div className={`col ${styles.gridItem}`}>{income.category}</div>
              <div className={`col ${styles.gridItem}`}>
                {income.amount} {income.currency}
              </div>
              <div className={`col ${styles.gridItem}`}>
                {income.receivedDate}
              </div>
              <div className="col">
                <Button text="Update" />
              </div>
            </div>
          );
        })
      )}
    </div>
  );
}

export default IncomesGrid;
