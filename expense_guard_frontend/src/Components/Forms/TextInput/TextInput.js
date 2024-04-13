import React from 'react'
import './TextInput.css'

function TextInput({labelText, inputId, placeholder}) {
    return <div class='form-group'>
        <label for={inputId}>{labelText}</label>
        <input type='text' class='form-control' id={inputId} aria-describedby={inputId} placeholder={placeholder}/>
    </div>
}

export default TextInput;