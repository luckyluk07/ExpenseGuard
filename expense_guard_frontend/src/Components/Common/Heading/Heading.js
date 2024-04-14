import React from 'react'
import './Heading.css'

function Heading({size, text}) {

    const getHeadingClass = () => {
        return `h${size}`;
    }

    return <div>
        <p className={getHeadingClass()}>{text}</p>
    </div>
}

export default Heading;