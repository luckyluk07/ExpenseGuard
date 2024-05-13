import React, { useState } from "react";
import { createPortal } from "react-dom";
import InvestmentModal from "../InvestmentModal/InvestmentModal";
import Button from "../../../Common/Button/Button";
import deleteApiRequest from "../../../Services/Api/deleteApiRequest";
import apiUrls from "../../../../Shared/apiUrls";

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
        <Button text="Update" />
        <Button
          text="Delete"
          onClick={() =>
            deleteApiRequest(apiUrls.deleteInvestment(investment.id))
          }
        />
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
