import React from "react";
import formStyles from "./formStyles.module.scss";

function PasswordInput({ labelText, inputId, placeholder, value, onChange }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };
  return (
    <div className="form-group">
      <label htmlFor={inputId} className={`${formStyles.label}`}>
        {labelText}
      </label>
      <input
        type="password"
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

export default PasswordInput;
