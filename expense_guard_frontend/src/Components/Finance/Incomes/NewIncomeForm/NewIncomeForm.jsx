import React from "react";
import TextInput from "../../../Forms/TextInput/TextInput";
import useFetchCategories from "../../../Hooks/useFetchCategories";
import Dropdown from "../../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../../Hooks/useFetchCurrencies";

function NewIncomeForm() {
  const { data: categories } = useFetchCategories();
  const { date: currencies } = useFetchCurrencies();
  return (
    <div className="container my-5">
      <h3>New income form</h3>
      <div className="w-50">
        <TextInput labelText="Name" placeholder="eg. Salary" />
        <TextInput labelText="Amount" placeholder="eg. 255.5" />
        <Dropdown options={categories} name="incomeCategory" />
        <Dropdown options={currencies} name="incomeCurrency" />
        {/* TODO fix selecting currency */}
      </div>
    </div>
  );
}

export default NewIncomeForm;
