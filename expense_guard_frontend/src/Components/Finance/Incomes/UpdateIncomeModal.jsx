/* eslint-disable jsx-a11y/no-static-element-interactions */
/* eslint-disable jsx-a11y/click-events-have-key-events */
import React from "react";
import styles from "../../styles/Modal.module.scss";
import UpdateIncomeForm from "./UpdateIncomeForm";

function UpdateIncomeModal({ income, onClose }) {
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
          <h5 className={styles["modal-title"]}>{income.name}</h5>
          <button
            onClick={onClose}
            type="button"
            className="btn-close"
            aria-label="Close"
          />
        </div>
        <div className={styles["modal-body"]}>
          <UpdateIncomeForm income={income} />
        </div>
      </div>
    </div>
  );
}

export default UpdateIncomeModal;
