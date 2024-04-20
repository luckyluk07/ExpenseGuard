import React from 'react'
import './Pagination.css'

function Pagination({pages}) {
    return <nav aria-label="Page navigation example">
    <ul class="pagination">
      <li class="page-item"><a class="page-link" href="#">Previous</a></li>
      {pages.map(page => {
        return <li class="page-item"><a class="page-link" href={page.link}>{page.label}</a></li>
      })}
      <li class="page-item"><a class="page-link" href="#">Next</a></li>
    </ul>
  </nav>
}

export default Pagination;