import React from "react";
import { NavLink } from "react-router-dom";
import styles from "./NavBar.module.scss";

function NavBar({ links }) {
  return (
    <nav className={`navbar navbar-expand-lg ${styles.navigationLine}`}>
      <div className="container-fluid">
        {/* todo change href */}
        <div className={styles.navigationItem}>
          <NavLink to="/">Home</NavLink>
        </div>
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
              return (
                <div className={styles.navigationItem}>
                  <NavLink to={link.url}>{link.name}</NavLink>
                </div>
              );
            })}
          </div>
        </div>
      </div>
    </nav>
  );
}

export default NavBar;
