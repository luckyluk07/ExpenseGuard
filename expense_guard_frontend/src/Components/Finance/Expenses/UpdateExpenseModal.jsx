/* eslint-disable jsx-a11y/click-events-have-key-events */
/* eslint-disable jsx-a11y/no-static-element-interactions */
import React from "react";
import styles from "../../styles/Modal.module.scss";
import UpdateExpenseForm from "./UpdateExpenseForm";

function UpdateExpenseModal({
  id,
  spendDate,
  name,
  amount,
  currency,
  category,
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
          <h5 className={styles["modal-title"]}>{name}</h5>
          <button
            onClick={onClose}
            type="button"
            className="btn-close"
            aria-label="Close"
          />
        </div>
        <div className={styles["modal-body"]}>
          <UpdateExpenseForm
            onClose={onClose}
            id={id}
            price={amount}
            currencyId={currency}
            categoryId={category}
            spendDate={spendDate}
          />
        </div>
      </div>
    </div>
  );
}

export default UpdateExpenseModal;
