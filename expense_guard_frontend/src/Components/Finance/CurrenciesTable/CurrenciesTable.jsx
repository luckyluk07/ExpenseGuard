import React from "react";

function CurrenciesTable({ currencies }) {
  return (
    <div className="w-25">
      <ul className="list-group">
        {currencies.map((element) => {
          return (
            <li className="list-group-item d-flex justify-content-between align-items-center">
              {element.name}
              <span>{element.price}</span>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

export default CurrenciesTable;
