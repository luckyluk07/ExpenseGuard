import React from "react";

function DatePicker({ value, onChange, label }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };

  return (
    <div>
      <label htmlFor="start">
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
