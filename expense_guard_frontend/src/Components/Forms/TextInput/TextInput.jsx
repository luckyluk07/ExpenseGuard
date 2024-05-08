import React from "react";
import styles from "./TextInput.module.scss";

function TextInput({ labelText, inputId, placeholder, value, onChange }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };
  return (
    <div className="form-group">
      <label htmlFor={inputId} className={`${styles.label}`}>
        {labelText}
      </label>
      <input
        type="text"
        className="form-control"
        id={inputId}
        value={value}
        onChange={handleSelectChange}
        aria-describedby={inputId}
        placeholder={placeholder}
      />
    </div>
  );
}

export default TextInput;
