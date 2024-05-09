import React from "react";

function DatePicker({ value, onChange }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };

  return (
    <div>
      <label htmlFor="start">
        Received Date:
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
