import React from "react";
import formStyles from "../formStyles.module.scss";

function Dropdown({ options, name, value, onChange }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };

  return (
    <div>
      <label htmlFor={name} className={`${formStyles.label}`}>
        Choose an option:
        <select
          name={name}
          id={name}
          value={value}
          onChange={handleSelectChange}
        >
          <option value="">--Please choose an option--</option>
          {options &&
            options.map((option) => {
              return (
                <option value={option.id} key={option.name}>
                  {option.name}
                </option>
              );
            })}
        </select>
      </label>
    </div>
  );
}

export default Dropdown;
