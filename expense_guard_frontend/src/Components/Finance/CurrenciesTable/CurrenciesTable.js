import React from 'react'
import './CurrenciesTable.css'

function CurrenciesTable({currencies}) {
    return <div class='w-25'>
                <ul class="list-group">
                    {currencies.map(element => {
                        return <li class="list-group-item d-flex justify-content-between align-items-center">
                            {element.name}
                            <span>
                                {element.price}
                            </span>
                        </li>
                    })}
                </ul>
            </div>
}

export default CurrenciesTable;