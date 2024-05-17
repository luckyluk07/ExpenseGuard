import React, { useState } from "react";
import { createPortal } from "react-dom";
import styles from "./ExpenseBadge.module.scss";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";
import UpdateExpenseModal from "../UpdateExpenseModal";

function ExpenseBadge({
  id,
  name,
  money,
  spendDate,
  category,
  description,
  classname,
}) {
  const [showModal, setShowModal] = useState(false);
  return (
    <div>
      <div
        className={`${styles.containerSkin} ${styles.containerShape} ${classname}`}
      >
        <h3>{name}</h3>
        <h5> {category.name}</h5>
        <h4>
          {money.amount} {money.currency.code}
        </h4>
        <p>{description}</p>
        <div>
          <Button text="Update" onClick={() => setShowModal(true)} />
          <Button
            text="Delete"
            onClick={() => deleteApiRequest(apiUrls.deleteExpense(id))}
          />
        </div>
      </div>
      {showModal &&
        createPortal(
          <UpdateExpenseModal
            id={id}
            name={name}
            amount={money.amount}
            currency={money.currency.id}
            category={category.id}
            spendDate={spendDate}
            onClose={() => setShowModal(false)}
          />,
          document.getElementById("portal"),
        )}
    </div>
  );
}

export default ExpenseBadge;
