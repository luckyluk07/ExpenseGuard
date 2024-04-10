import React from 'react';
import './InvestmentDepositBadge.css'; 

function InvestmentDepositBadge(props) {
  return (
    <div className='containerSkinInvestment containerShapeInvestment'>
        <h3>{props.name}</h3>
        <h4>Date range: {props.startDate} - {props.endDate}</h4>
        <h4>{props.startMoney.amount} {props.startMoney.currency.code}</h4>
        <p>Year capitalization: {props.yearCapitalizationAmount}, with year interest rate of {props.interestRate}</p>
    </div>
  );
}

export default InvestmentDepositBadge;