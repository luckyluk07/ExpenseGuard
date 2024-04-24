import React from "react";
import "./Pagination.scss";

function Pagination({ pages }) {
  return (
    <nav aria-label="Page navigation example">
      <ul className="pagination">
        <li className="page-item">
          <a className="page-link" href="#">
            Previous
          </a>
        </li>
        {pages.map((page) => {
          return (
            <li className="page-item">
              <a className="page-link" href={page.link}>
                {page.label}
              </a>
            </li>
          );
        })}
        <li className="page-item">
          <a className="page-link" href="#">
            Next
          </a>
        </li>
      </ul>
    </nav>
  );
}

export default Pagination;
