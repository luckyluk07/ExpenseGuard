import React from "react";
import "./TextInput.scss";

function TextInput({ labelText, inputId, placeholder }) {
  return (
    <div className="form-group">
      <label htmlFor={inputId}>{labelText}</label>
      <input
        type="text"
        className="form-control"
        id={inputId}
        aria-describedby={inputId}
        placeholder={placeholder}
      />
    </div>
  );
}

export default TextInput;
