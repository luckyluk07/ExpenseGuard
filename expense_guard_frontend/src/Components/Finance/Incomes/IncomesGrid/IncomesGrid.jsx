import React, { useState } from "react";
import { createPortal } from "react-dom";
import styles from "./IncomesGrid.module.scss";
import NoDataAvailable from "../../../../Pages/NoDataAvailable";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";
import UpdateIncomeModal from "../UpdateIncomeModal";

const RESOURCE_NUMBER = "Number";
const RESOURCE_NAME = "Name";
const RESOURCE_CATEGORY = "Category";
const RESOURCE_MONEY = "Money";
const RESOURCE_RECEIVED = "Received";
const RESOURCE_UPDATE = "Update";
const RESOURCE_DELETE = "Delete";

function IncomesGrid({ incomes }) {
  const [showModal, setShowModal] = useState(false);
  const [modalIncome, setModalIncome] = useState(undefined);
  return (
    <div>
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
          <div className={`col ${styles.headerItem} ${styles.gridItem}`}>
            {RESOURCE_DELETE}
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
                <div className={`col ${styles.gridItem}`}>
                  {income.category}
                </div>
                <div className={`col ${styles.gridItem}`}>
                  {income.amount} {income.currency}
                </div>
                <div className={`col ${styles.gridItem}`}>
                  {income.receivedDate}
                </div>
                <div className="col">
                  <Button
                    text="Update"
                    onClick={() => {
                      setShowModal(true);
                      setModalIncome(income);
                    }}
                  />
                </div>
                <div className="col">
                  <Button
                    text="Delete"
                    onClick={() =>
                      deleteApiRequest(apiUrls.deleteIncome(income.id))
                    }
                  />
                </div>
              </div>
            );
          })
        )}
      </div>
      {showModal &&
        createPortal(
          <UpdateIncomeModal
            income={modalIncome}
            onClose={() => {
              setShowModal(false);
              setModalIncome(undefined);
            }}
          />,
          document.getElementById("portal"),
        )}
    </div>
  );
}

export default IncomesGrid;
