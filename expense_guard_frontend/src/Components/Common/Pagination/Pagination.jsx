import React from "react";

function Pagination({ pages }) {
  return (
    <nav aria-label="Page navigation example">
      <ul className="pagination">
        <li className="page-item">
          <a className="page-link" href="/prev">
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
          <a className="page-link" href="/next">
            Next
          </a>
        </li>
      </ul>
    </nav>
  );
}

export default Pagination;
