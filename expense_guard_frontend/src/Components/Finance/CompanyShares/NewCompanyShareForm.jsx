import React, { useState } from "react";
import TextInput from "../../Forms/TextInput/TextInput";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../Hooks/useFetchCurrencies";
import postApiRequest from "../../Services/Api/makePostApiRequest";
import apiUrls from "../../../Shared/apiUrls";
import DatePicker from "../../Forms/DatePicker/DatePicker";
import NumericInput from "../../Forms/NumericInput/NumericInput";

function NewCompanyShareForm({ onDone }) {
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState("");
  const [amount, setAmount] = useState(0);
  const [price, setPrice] = useState(0);
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
            labelText="Shares amount"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
            value={amount}
            onChange={(newAmount) => setAmount(newAmount)}
          />
          <NumericInput
            labelText="Price"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
            value={price}
            onChange={(newAmount) => setPrice(newAmount)}
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
            label="Date of purchase"
            value={date}
            onChange={(newDate) => setDate(newDate)}
          />
          <button
            type="submit"
            onClick={async (event) => {
              const data = {
                name,
                dateOfPurchase: date,
                sharesAmount: amount,
                price,
                currencyId: currency,
                financeId: 1,
              };
              const responseObject = await postApiRequest(
                apiUrls.postCompanyShares,
                data,
              );
              onDone(responseObject);
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

export default NewCompanyShareForm;
