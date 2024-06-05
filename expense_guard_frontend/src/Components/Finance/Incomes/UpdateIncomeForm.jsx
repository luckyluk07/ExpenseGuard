import React, { useState } from "react";
import useFetchCategories from "../../Hooks/useFetchCategories";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../Hooks/useFetchCurrencies";
import apiUrls from "../../../Shared/apiUrls";
import DatePicker from "../../Forms/DatePicker/DatePicker";
import NumericInput from "../../Forms/NumericInput/NumericInput";
import { updateApiRequest } from "../../Services/Api/updateApiRequest";

function UpdateIncomeForm({ income }) {
  const { data: categories } = useFetchCategories();
  const { data: currencies } = useFetchCurrencies();

  const [amount, setAmount] = useState(income.amount);
  const [category, setCategory] = useState(income.categoryId);
  const [currency, setCurrency] = useState(income.currencyId);
  const [date, setDate] = useState(income.receivedDate);

  return (
    <div className="container my-5">
      <h3>Update income form</h3>
      <div className="w-50">
        <form>
          <NumericInput
            labelText="Amount"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
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
          <DatePicker
            label="Received date"
            value={date}
            onChange={(newDate) => setDate(newDate)}
          />
          <button
            type="submit"
            onClick={async (event) => {
              const data = {
                receivedDate: new Date(date),
                amount,
                currencyId: currency,
                categoryId: category,
              };
              await updateApiRequest(apiUrls.updateIncome(income.id), data);
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

export default UpdateIncomeForm;
