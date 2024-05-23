import React, { useState } from "react";
import useFetchCategories from "../../Hooks/useFetchCategories";
import Dropdown from "../../Forms/Dropdown/Dropdown";

// todo it should be category dropdown, toggle - radio button, text inputs
function CategoryPicker() {
  const { data: categories } = useFetchCategories();
  const [category, setCategory] = useState(undefined);
  return (
    <div>
      <Dropdown
        options={categories}
        name="expenseCategory"
        value={category}
        onChange={(option) => {
          setCategory(option);
        }}
      />
    </div>
  );
}

export default CategoryPicker;
