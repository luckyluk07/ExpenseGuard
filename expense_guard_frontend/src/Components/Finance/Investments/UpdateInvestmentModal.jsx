/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
import React from "react";
import styles from "../../styles/Modal.module.scss";
import UpdateInvestmentForm from "./UpdateInvestmentForm";

function UpdateInvestmentModal({ investment, onClose }) {
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
          <UpdateInvestmentForm investment={investment} />
        </div>
      </div>
    </div>
  );
}

export default UpdateInvestmentModal;
