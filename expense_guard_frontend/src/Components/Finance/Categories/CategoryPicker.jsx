import React, { useState, useEffect } from "react";
import useFetchCategories from "../../Hooks/useFetchCategories";
import { postApiRequest } from "../../Services/Api/makePostApiRequest";
import TextInput from "../../Forms/TextInput/TextInput";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import Button from "../../Common/Button/Button";
import apiUrls from "../../../Shared/apiUrls";

function CategoryPicker({ onDone, categ }) {
  const { data: fetchedCategories } = useFetchCategories();
  const [categories, setCategories] = useState();
  const [newCategoryDisplay, setNewCategoryDispaly] = useState(false);
  const [newCategoryName, setNewCategoryName] = useState("");

  useEffect(() => {
    setCategories(fetchedCategories);
  }, [fetchedCategories]);

  return (
    <div>
      {!newCategoryDisplay && (
        <Dropdown
          options={categories}
          name="expenseCategory"
          value={categ}
          onChange={(option) => {
            onDone(option);
          }}
        />
      )}
      {newCategoryDisplay && (
        <div>
          <TextInput
            labelText="New category name"
            onChange={(text) => setNewCategoryName(text)}
          />
          <Button
            text="submit"
            onClick={async (event) => {
              const data = {
                name: newCategoryName,
                description: newCategoryName,
              };
              const responseObject = await postApiRequest(
                apiUrls.postCategory,
                data,
              );
              const newCategory = {
                id: responseObject.id,
                name: responseObject.name,
                description: responseObject.description,
              };
              setCategories((prevValue) => [...prevValue, newCategory]);
              onDone(responseObject.id);
              setNewCategoryDispaly((prev) => !prev);
              event.preventDefault();
            }}
          />
        </div>
      )}
      <div className="form-check form-switch">
        <label className="form-check-label" htmlFor="flexSwitchCheckDefault">
          <input
            className="form-check-input"
            type="checkbox"
            role="switch"
            onChange={() => {
              setNewCategoryDispaly((prevValue) => !prevValue);
            }}
            id="flexSwitchCheckDefault"
          />
          Add own category
        </label>
      </div>
    </div>
  );
}

export default CategoryPicker;
