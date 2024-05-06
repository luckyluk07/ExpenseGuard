import React from "react";
import styles from "./TextInput.module.scss";

function TextInput({ labelText, inputId, placeholder }) {
  return (
    <div className="form-group">
      <label htmlFor={inputId} className={`${styles.label}`}>
        {labelText}
      </label>
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
