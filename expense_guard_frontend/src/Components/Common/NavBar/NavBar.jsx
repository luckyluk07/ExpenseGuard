import React from "react";
import { NavLink } from "react-router-dom";

function NavBar({ links }) {
  return (
    <nav className="navbar navbar-expand-lg bg-light">
      <div className="container-fluid">
        {/* todo change href */}
        <NavLink to="/">Home</NavLink>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon" />
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <div className="navbar-nav">
            {links.map((link) => {
              return <NavLink to={link.url}>{link.name}</NavLink>;
            })}
          </div>
        </div>
      </div>
    </nav>
  );
}

export default NavBar;
