import React from "react";
import styles from "./IncomesGrid.module.scss";
import NoDataAvailable from "../../../../Pages/NoDataAvailable";

const RESOURCE_NUMBER = "Number";
const RESOURCE_NAME = "Name";
const RESOURCE_CATEGORY = "Category";
const RESOURCE_MONEY = "Money";
const RESOURCE_RECEIVED = "Received";

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
      </div>
      {!incomes || incomes.length === 0 ? (
        <NoDataAvailable />
      ) : (
        incomes.map((income, index) => {
          console.log(income);
          return (
            <div className="row">
              <div className={`col ${styles.gridItem}`}>{index + 1}</div>
              <div className={`col ${styles.gridItem}`}>{income.name}</div>
              <div className={`col ${styles.gridItem}`}>{income.category}</div>
              <div className={`col ${styles.gridItem}`}>
                {income.amount} {income.currency}
              </div>
              <div className={`col ${styles.gridItem}`}>
                {income.receivedDate}
              </div>
            </div>
          );
        })
      )}
    </div>
  );
}

export default IncomesGrid;
