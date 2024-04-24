import React from "react";
import "./IncomeBadge.scss";

function IncomeBadge({ name, money, category, receivedDate }) {
  return (
    <div className="incomeBadgeContainerShape incomeBadgeContainerSkin">
      <h3>
        {name} {category.name} {receivedDate}
      </h3>
      <h4>
        {money.amount} {money.currency.code}
      </h4>
    </div>
  );
}

export default IncomeBadge;
