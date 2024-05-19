import React, { useState } from "react";
import TextInput from "../../Forms/TextInput/TextInput";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../Hooks/useFetchCurrencies";
import apiUrls from "../../../Shared/apiUrls";
import DatePicker from "../../Forms/DatePicker/DatePicker";
import NumericInput from "../../Forms/NumericInput/NumericInput";
import updateApiRequest from "../../Services/Api/updateApiRequest";

function UpdateCompanyShareForm({
  id,
  shareName,
  shareAmount,
  sharePrice,
  shareCurrency,
  shareDate,
}) {
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState(shareName);
  const [amount, setAmount] = useState(shareAmount);
  const [price, setPrice] = useState(sharePrice);
  const [currency, setCurrency] = useState(shareCurrency);
  const [date, setDate] = useState(shareDate);

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
                dateOfPurchase: new Date(date),
                sharesAmount: amount,
                price,
                currencyId: currency,
              };
              await updateApiRequest(apiUrls.updateCompanyShares(id), data);
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

export default UpdateCompanyShareForm;
