import React from "react";

const RESOURCE_INTEREST_RATE_TEXT = "Interest rate";
const RESOURCE_YEAR_TEXT = "year";
const RESOURCE_YEAR_CAPITALIZATION_AMOUNT_TEXT = "Year capitalization amount";
const RESOURCE_DESCRIPTION_AND_COMMENTS_TEXT = "Description and comments";

function InvestmentModal({ investment, onClose }) {
  return (
    <div className="modal-content">
      <div className="modal-header">
        <h5 className="modal-title">{investment.name}</h5>
        <button
          onClick={onClose}
          type="button"
          className="btn-close"
          aria-label="Close"
        />
      </div>
      <div className="modal-body">
        <p>
          {`${investment.startMoney.amount} ${investment.startMoney.currency} ${investment.startDate}-${investment.endDate}`}
          {`${RESOURCE_INTEREST_RATE_TEXT}: ${investment.interestRate}`}
        </p>
        <p>{`${RESOURCE_YEAR_CAPITALIZATION_AMOUNT_TEXT}: ${investment.yearCapitalizationAmount}/${RESOURCE_YEAR_TEXT}`}</p>
        <p>{`${RESOURCE_DESCRIPTION_AND_COMMENTS_TEXT}: ${investment.description}`}</p>
      </div>
    </div>
  );
}

export default InvestmentModal;
