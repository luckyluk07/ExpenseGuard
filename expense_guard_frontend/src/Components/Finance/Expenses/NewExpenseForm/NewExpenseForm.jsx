import React, { useState } from "react";
import TextInput from "../../../Forms/TextInput/TextInput";
import useFetchCategories from "../../../Hooks/useFetchCategories";
import Dropdown from "../../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../../Hooks/useFetchCurrencies";
import postApiRequest from "../../../Services/Api/makePostApiRequest";
import apiUrls from "../../../../Shared/apiUrls";
import DatePicker from "../../../Forms/DatePicker/DatePicker";
import NumericInput from "../../../Forms/NumericInput/NumericInput";

function NewExpenseForm() {
  const { data: categories } = useFetchCategories();
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState("");
  const [amount, setAmount] = useState(0);
  const [category, setCategory] = useState(undefined);
  const [currency, setCurrency] = useState(undefined);
  const [date, setDate] = useState(new Date());

  return (
    <div className="container my-5">
      <h3>New income form</h3>
      <div className="w-50 mx-auto p-3 border border-dark rounded">
        <form>
          <TextInput
            labelText="Name"
            placeholder="eg. Salary"
            value={name}
            onChange={(newName) => setName(newName)}
          />
          <NumericInput
            labelText="Price"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
            value={amount}
            onChange={(newAmount) => setAmount(newAmount)}
          />
          <Dropdown
            options={categories}
            name="expenseCategory"
            value={category}
            onChange={(option) => {
              setCategory(option);
            }}
          />
          <Dropdown
            options={currencies}
            name="expenseCurrency"
            value={currency}
            onChange={(option) => {
              setCurrency(option);
            }}
          />
          <DatePicker
            label="Spend date"
            value={date}
            onChange={(newDate) => setDate(newDate)}
          />
          <button
            type="submit"
            onClick={(event) => {
              const data = {
                name,
                spendDate: date,
                price: amount,
                currencyId: currency,
                categoryId: category,
                financeId: 1,
              };
              postApiRequest(apiUrls.postExpense, data);
              event.preventDefault();
            }}
          >
            Submit
          </button>
        </form>
      </div>
    </div>
  );
}

export default NewExpenseForm;
