import React from "react";
import styles from "./ExpenseBadge.module.scss";

function ExpenseBadge({ name, money, description, classname }) {
  return (
    <div
      className={`${styles.containerSkin} ${styles.containerShape} ${classname}`}
    >
      <h3>{name}</h3>
      <h4>
        {money.amount} {money.currency.code}
      </h4>
      <p>{description}</p>
    </div>
  );
}

export default ExpenseBadge;