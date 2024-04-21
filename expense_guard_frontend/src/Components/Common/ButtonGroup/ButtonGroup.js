import React from 'react'
import './ButtonGroup.css'

function ButtonGroup({buttons}) {
    return <div class="btn-group" role="group" aria-label="Basic example">
                {buttons.map(button => {
                    return <button type="button" class="btn btn-primary">{button.label}</button>
                })}
            </div>
}

export default ButtonGroup;