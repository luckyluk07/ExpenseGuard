import React, { useState } from "react";
import TextInput from "../../Forms/TextInput/TextInput";
import Dropdown from "../../Forms/Dropdown/Dropdown";
import useFetchCurrencies from "../../Hooks/useFetchCurrencies";
import apiUrls from "../../../Shared/apiUrls";
import DatePicker from "../../Forms/DatePicker/DatePicker";
import NumericInput from "../../Forms/NumericInput/NumericInput";
import { updateApiRequest } from "../../Services/Api/updateApiRequest";

function UpdateInvestmentForm({ investment }) {
  const { data: currencies } = useFetchCurrencies();

  const [name, setName] = useState(investment.name);
  const [amount, setAmount] = useState(investment.startMoney.amount);
  const [currency, setCurrency] = useState(investment.startMoney.currencyId);
  const [startDate, setStartDate] = useState(investment.startDate);
  const [endDate, setEndDate] = useState(investment.endDate);
  const [yearCapitalizationAmount, setYearCapizalizationAmount] = useState(
    investment.yearCapitalizationAmount,
  );
  const [interstRate, setInterestRate] = useState(investment.interestRate);

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
            labelText="Price"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
            value={amount}
            onChange={(newAmount) => setAmount(newAmount)}
          />
          <NumericInput
            labelText="Year capitalization amount"
            placeholder="eg. 3"
            min={0}
            step={1}
            value={yearCapitalizationAmount}
            onChange={(newAmount) => setYearCapizalizationAmount(newAmount)}
          />
          <NumericInput
            labelText="Interest rate"
            placeholder="eg. 255.5"
            min={0}
            step={0.01}
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
            onChange={(newDate) => {
              setStartDate(newDate);
            }}
          />
          <DatePicker
            label="End date"
            value={endDate}
            onChange={(newDate) => setEndDate(newDate)}
          />
          <button
            type="submit"
            onClick={async (event) => {
              const data = {
                name,
                startDate: new Date(startDate),
                endDate: new Date(endDate),
                yearCapitalizationAmount,
                interestRate: interstRate,
                startMoney: {
                  amount,
                  currencyId: currency,
                },
              };
              await updateApiRequest(
                apiUrls.updateInvestment(investment.id),
                data,
              );
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
