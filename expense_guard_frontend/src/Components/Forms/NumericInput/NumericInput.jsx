import React from "react";
import formStyles from "../formStyles.module.scss";

function NumericInput({
  labelText,
  inputId,
  placeholder,
  value,
  onChange,
  step,
  min,
  max,
}) {
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
        type="number"
        className="form-control"
        min={min}
        max={max}
        step={step}
        id={inputId}
        value={value}
        onChange={handleSelectChange}
        aria-describedby={inputId}
        placeholder={placeholder}
      />
    </div>
  );
}

export default NumericInput;
