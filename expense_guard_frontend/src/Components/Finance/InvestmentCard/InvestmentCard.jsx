import React, { useState } from "react";
import { createPortal } from "react-dom";
import InvestmentModal from "../InvestmentModal/InvestmentModal";

const RESOURCE_SEE_DETAILS_LABEL = "See details";

function InvestmentCard({ investment }) {
  const [showModal, setShowModal] = useState(false);
  return (
    <div className="card w-25 m-auto mb-2">
      <div className="card-body">
        <h5 className="card-title">{investment.name}</h5>
        <p className="card-text">
          {`${investment.startDate}-${investment.endDate}: ${investment.startMoney.amount} ${investment.startMoney.currency}`}
        </p>
        <button
          type="button"
          onClick={() => {
            setShowModal(true);
          }}
          className="btn btn-primary"
        >
          {RESOURCE_SEE_DETAILS_LABEL}
        </button>
      </div>

      {showModal &&
        createPortal(
          <InvestmentModal
            investment={investment}
            onClose={() => setShowModal(false)}
          />,
          document.body,
        )}
    </div>
  );
}
export default InvestmentCard;
