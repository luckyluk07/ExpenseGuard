import React from "react";

function Dropdown({ options, name, value, onChange }) {
  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    onChange(selectedValue);
  };

  return (
    <div>
      <label htmlFor={name}>
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
