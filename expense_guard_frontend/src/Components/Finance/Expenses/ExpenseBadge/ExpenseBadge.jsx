import React from "react";
import styles from "./ExpenseBadge.module.scss";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";

function ExpenseBadge({ id, name, money, description, classname }) {
  return (
    <div
      className={`${styles.containerSkin} ${styles.containerShape} ${classname}`}
    >
      <h3>{name}</h3>
      <h4>
        {money.amount} {money.currency.code}
      </h4>
      <p>{description}</p>
      <div>
        <Button text="Update" />
        <Button
          text="Delete"
          onClick={() => deleteApiRequest(apiUrls.deleteExpense(id))}
        />
      </div>
    </div>
  );
}

export default ExpenseBadge;
