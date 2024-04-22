import React from "react";
import "./ActionCard.css";

import Heading from "../../Common/Heading/Heading";
import Text from "../../Common/Text/Text";
import Button from "../../Common/Button/Button";

// todo add styles and text based on category
// todo below should also open modal
function ActionCard({ category, name, amount, currency }) {
  return (
    <div className="card w-50">
      <div className="card">
        <div className="card-header">{category}</div>
        <div className="card-body">
          <Heading size={6} text={name} />
          <Text bold={false} content={`${amount} ${currency}`} />
          <Button
            text="Display details"
            onClick={() => alert("Here will be details")}
          />
        </div>
      </div>
    </div>
  );
}

export default ActionCard;
