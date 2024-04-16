import React from 'react';
import './ExpenseBadge.css'; 

function ExpenseBadge({name, money, description}) {
  return (
    <div className='containerSkin containerShape'>
        <h3>{name}</h3>
        <h4>{money.amount} {money.currency.code}</h4>
        <p>{description}</p>
    </div>
  );
}

export default ExpenseBadge;