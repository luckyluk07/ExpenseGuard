import React from "react";
import "./Dropdown.css";

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
        {options.map((element, index) => (
          <li key={index}>
            <a className="dropdown-item" href="#">
              {element.name}
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Dropdown;
