import React from "react";
import styles from "./UpdateIncomeModal.module.scss";
import UpdateIncomeForm from "../UpdateIncomeForm/UpdateIncomeForm";

function UpdateIncomeModal({ investment, onClose }) {
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
        <UpdateIncomeForm />
      </div>
    </div>
  );
}

export default UpdateIncomeModal;
