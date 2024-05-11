import React, { useState } from "react";
import TextInput from "../../../Forms/TextInput/TextInput";
import Dropdown from "../../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../../Hooks/useFetchCurrencies";
import postApiRequest from "../../../Services/Api/makePostApiRequest";
import apiUrls from "../../../../Shared/apiUrls";
import DatePicker from "../../../Forms/DatePicker/DatePicker";

function UpdateInvestmentForm() {
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState("");
  const [amount, setAmount] = useState(0);
  const [currency, setCurrency] = useState(undefined);
  const [startDate, setStartDate] = useState(new Date());
  const [endDate, setEndDate] = useState(new Date());
  const [yearCapitalizationAmount, setYearCapizalizationAmount] = useState(0);
  const [interstRate, setInterestRate] = useState(0);

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
            labelText="Price"
            placeholder="eg. 255.5"
            value={amount}
            onChange={(newAmount) => setAmount(newAmount)}
          />
          <TextInput
            labelText="Year capitalization amount"
            placeholder="eg. 3"
            value={yearCapitalizationAmount}
            onChange={(newAmount) => setYearCapizalizationAmount(newAmount)}
          />
          <TextInput
            labelText="Interest rate"
            placeholder="eg. 255.5"
            value={interstRate}
            onChange={(newAmount) => setInterestRate(newAmount)}
          />
          <Dropdown
            options={currencies}
            name="investmentCurrency"
            value={currency}
            onChange={(option) => {
              setCurrency(option);
            }}
          />
          <DatePicker
            label="Start date"
            value={startDate}
            onChange={(newDate) => setStartDate(newDate)}
          />
          <DatePicker
            label="End date"
            value={endDate}
            onChange={(newDate) => setEndDate(newDate)}
          />
          <button
            type="submit"
            onClick={(event) => {
              const data = {
                name,
                startDate,
                endDate,
                yearCapitalizationAmount,
                interestRate: interstRate,
                startMoney: {
                  amount,
                  currencyId: currency,
                },
                financeId: 1,
              };
              postApiRequest(apiUrls.postInvestment, data);
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

export default UpdateInvestmentForm;
