import React from "react";
import "./Dropdown.scss";

function Dropdown({ options }) {
  return (
    <div className="dropdown">
      <button
        className="btn btn-secondary dropdown-toggle"
        type="button"
        data-bs-toggle="dropdown"
        aria-expanded="false"
      >
        Dropdown button
      </button>
      <ul className="dropdown-menu">
        {options.map((element) => (
          <li key={`${element.name}`}>
            <a className="dropdown-item" href={`/${element.name}`}>
              {element.name}
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Dropdown;
