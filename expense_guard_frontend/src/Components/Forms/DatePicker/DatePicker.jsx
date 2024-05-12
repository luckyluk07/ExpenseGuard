import React from "react";
import formStyles from "../formStyles.module.scss";

function DatePicker({ value, onChange, label }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };

  return (
    <div>
      <label htmlFor="start" className={`${formStyles.label}`}>
        {label}
        <input
          type="date"
          id="start"
          name="trip-start"
          value={value}
          onChange={handleSelectChange}
        />
      </label>
    </div>
  );
}

export default DatePicker;
