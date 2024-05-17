import React from "react";
import styles from "./ExpenseList.module.scss";
import ExpenseBadge from "../ExpenseBadge/ExpenseBadge";
import NoDataAvailable from "../../../../Pages/NoDataAvailable";

function ExpenseList({ expenses }) {
  return (
    <div>
      {!expenses || expenses.length === 0 ? (
        <NoDataAvailable />
      ) : (
        expenses.map((expense) => {
          return (
            <ExpenseBadge
              id={expense.id}
              name={expense.name}
              category={expense.category}
              description={expense.description}
              money={expense.money}
              spendDate={expense.spendDate}
              classname={styles.badgeMargins}
            />
          );
        })
      )}
    </div>
  );
}

export default ExpenseList;
