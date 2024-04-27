import React from "react";
import styles from "./IncomesGrid.module.scss";

const RESOURCE_NUMBER = "Number";
const RESOURCE_NAME = "Name";
const RESOURCE_CATEGORY = "Category";
const RESOURCE_MONEY = "Money";
const RESOURCE_RECEIVED = "Received";

function IncomesGrid({ incomes }) {
  return (
    <div className={`container ${styles.gridSkin}`}>
      <div className="row">
        <div className={`col ${styles.headerItem}`}>{RESOURCE_NUMBER}</div>
        <div className={`col ${styles.headerItem}`}>{RESOURCE_NAME}</div>
        <div className={`col ${styles.headerItem}`}>{RESOURCE_CATEGORY}</div>
        <div className={`col ${styles.headerItem}`}>{RESOURCE_MONEY}</div>
        <div className={`col ${styles.headerItem}`}>{RESOURCE_RECEIVED}</div>
      </div>
      {incomes.map((income, index) => {
        return (
          <div className="row">
            <div className={`col ${styles.gridItem}`}>{index + 1}</div>
            <div className={`col ${styles.gridItem}`}>{income.name}</div>
            <div className={`col ${styles.gridItem}`}>{income.category}</div>
            <div className={`col ${styles.gridItem}`}>{income.money}</div>
            <div className={`col ${styles.gridItem}`}>
              {income.receivedDate}
            </div>
          </div>
        );
      })}
    </div>
  );
}

export default IncomesGrid;
