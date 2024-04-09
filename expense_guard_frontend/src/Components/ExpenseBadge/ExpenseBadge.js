import React from 'react';
import './ExpenseBadge.css'; 

function ExpenseBadge(props) {
  return (
    <div className='containerSkin containerShape'>
        <h3>{props.name}</h3>
        <h4>{props.money.amount} {props.money.currency.code}</h4>
        <p>{props.description}</p>
    </div>
  );
}

export default ExpenseBadge;