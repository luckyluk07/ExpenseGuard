import React, { useState } from "react";
import TextInput from "../../../Forms/TextInput/TextInput";
import useFetchCategories from "../../../Hooks/useFetchCategories";
import Dropdown from "../../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../../Hooks/useFetchCurrencies";

function NewIncomeForm() {
  const { data: categories } = useFetchCategories();
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState("");
  const [amount, setAmount] = useState(0);
  const [category, setCategory] = useState(
    categories.length === 0 ? undefined : categories[0],
  );
  const [currency, setCurrency] = useState(
    currencies.length === 0 ? undefined : currencies[0],
  );

  return (
    <div className="container my-5">
      <h3>New income form</h3>
      <div className="w-50">
        <form>
          <TextInput
            labelText="Name"
            placeholder="eg. Salary"
            value={name}
            onChange={(newName) => setName(newName)}
          />
          <TextInput
            labelText="Amount"
            placeholder="eg. 255.5"
            value={amount}
            onChange={(newAmount) => setAmount(newAmount)}
          />
          <Dropdown
            options={categories}
            name="incomeCategory"
            value={category}
            onChange={(option) => {
              setCategory(option);
            }}
          />
          <Dropdown
            options={currencies}
            name="incomeCurrency"
            value={currency}
            onChange={(option) => {
              setCurrency(option);
            }}
          />
          <button type="submit">Submit</button>
        </form>
        {/* TODO fix selecting currency */}
      </div>
    </div>
  );
}

export default NewIncomeForm;
