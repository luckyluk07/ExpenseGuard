import React from "react";
import styles from "./ExpenseList.module.scss";
import ExpenseBadge from "../ExpenseBadge/ExpenseBadge";
import NoDataAvailable from "../../../Pages/NoDataAvailable";

function ExpenseList({ expenses }) {
  return (
    <div>
      {!expenses || expenses.length === 0 ? (
        <NoDataAvailable />
      ) : (
        expenses.map((expense) => {
          return (
            <ExpenseBadge
              name={expense.name}
              description={expense.description}
              money={expense.money}
              classname={styles.badgeMargins}
            />
          );
        })
      )}
    </div>
  );
}

export default ExpenseList;
