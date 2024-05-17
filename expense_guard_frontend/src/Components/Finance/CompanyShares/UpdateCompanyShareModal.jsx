/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
import React from "react";
import styles from "../../styles/Modal.module.scss";
import UpdateCompanyShareForm from "./UpdateCompanyShareForm";

function UpdateCompanyShareModal({
  id,
  shareName,
  shareAmount,
  sharePrice,
  shareCurrency,
  shareDate,
  onClose,
}) {
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
          <h5 className={styles["modal-title"]}>{shareName}</h5>
          <button
            onClick={onClose}
            type="button"
            className="btn-close"
            aria-label="Close"
          />
        </div>
        <div className={styles["modal-body"]}>
          <UpdateCompanyShareForm
            onClose={onClose}
            id={id}
            shareName={shareName}
            shareAmount={shareAmount}
            sharePrice={sharePrice}
            shareCurrency={shareCurrency}
            shareDate={shareDate}
          />
        </div>
      </div>
    </div>
  );
}

export default UpdateCompanyShareModal;
