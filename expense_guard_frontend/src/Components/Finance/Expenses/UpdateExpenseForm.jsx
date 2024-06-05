import React, { useState } from "react";
import useFetchCategories from "../../Hooks/useFetchCategories";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../Hooks/useFetchCurrencies";
import apiUrls from "../../../Shared/apiUrls";
import DatePicker from "../../Forms/DatePicker/DatePicker";
import NumericInput from "../../Forms/NumericInput/NumericInput";
import { updateApiRequest } from "../../Services/Api/updateApiRequest";

function UpdateExpenseForm({
  onClose,
  id,
  price,
  currencyId,
  categoryId,
  spendDate,
}) {
  const { data: categories } = useFetchCategories();
  const { data: currencies } = useFetchCurrencies();

  const [amount, setAmount] = useState(price);
  const [category, setCategory] = useState(categoryId);
  const [currency, setCurrency] = useState(currencyId);
  const [date, setDate] = useState(spendDate);

  return (
    <div className="container my-5">
      <h3>New income form</h3>
      <div className="w-50">
        <form>
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
            onClick={async (event) => {
              const data = {
                spendDate: new Date(date),
                price: amount,
                currencyId: currency,
                categoryId: category,
              };
              await updateApiRequest(apiUrls.updateExpense(id), data);
              event.preventDefault();
              onClose();
            }}
          >
            Submit
          </button>
        </form>
      </div>
    </div>
  );
}

export default UpdateExpenseForm;
