import React from "react";
import formStyles from "../formStyles.module.scss";

function DatePicker({ value, onChange, label }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };
  const formatDate = (date) => {
    const d = new Date(date);
    let month = `${d.getMonth() + 1}`;
    let day = `${d.getDate()}`;
    let year = `${d.getFullYear()}`;

    if (year.length === 2) year = `00${year}`;
    else if (year.length === 3) year = `0${year}`;
    else if (year.length === 1) year = `000${year}`;

    if (month.length < 2) month = `0${month}`;
    if (day.length < 2) day = `0${day}`;

    return [year, month, day].join("-");
  };

  return (
    <div>
      <label htmlFor="start" className={`${formStyles.label}`}>
        {label}
        <input
          type="date"
          id="start"
          name="trip-start"
          value={formatDate(value)}
          onChange={handleSelectChange}
        />
      </label>
    </div>
  );
}

export default DatePicker;
