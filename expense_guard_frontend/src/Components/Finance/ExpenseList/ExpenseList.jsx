import React from "react";
import styles from "./ExpenseList.module.scss";
import ExpenseBadge from "../ExpenseBadge/ExpenseBadge";

function ExpenseList({ expenses }) {
  return (
    <div>
      {expenses.map((expense) => {
        return (
          <ExpenseBadge
            name={expense.name}
            description={expense.description}
            money={expense.money}
            classname={styles.badgeMargins}
          />
        );
      })}
    </div>
  );
}

export default ExpenseList;
