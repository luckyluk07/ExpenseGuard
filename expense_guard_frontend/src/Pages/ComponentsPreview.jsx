import React from "react";
import InvestmentDepositBadge from "../Components/Finance/Investments/InvestmentDeposit/InvestmentDepositBadge";
import ButtonGroup from "../Components/Common/ButtonGroup/ButtonGroup";
import Dropdown from "../Components/Forms/Dropdown/Dropdown";
import Heading from "../Components/Common/Heading/Heading";
import Pagination from "../Components/Common/Pagination/Pagination";
import CurrenciesTable from "../Components/Finance/CurrenciesTable/CurrenciesTable";
import DetailsModal from "../Components/Finance/DetailsModal/DetailsModal";
import CompanyShareBadge from "../Components/Finance/CompanyShares/CompanyShareBadge/CompanyShareBadge";
import TextInput from "../Components/Forms/TextInput/TextInput";
import Text from "../Components/Common/Text/Text";

export default function ComponentsPreview() {
  return (
    <div className="container">
      <h2>Investment deposit badge</h2>
      <InvestmentDepositBadge
        name="PKO BP - konto dla nowych"
        startDate="17 April 2024"
        endDate="17 June 2024"
        startMoney={{ amount: 200000, currency: { code: "PLN" } }}
        yearCapitalizationAmount={4}
        interestRate={6.0}
      />
      <h2>Income badge</h2>
      <CompanyShareBadge
        name="Salary"
        money={{ amount: 10000, currency: { code: "PLN" } }}
        dateOfPurchase="10 April 2024"
      />
      <h2>Dropdown</h2>
      <Dropdown
        options={[
          { name: "option1" },
          { name: "option2" },
          { name: "option3" },
        ]}
      />
      <h2>Text input component</h2>
      <TextInput
        labelText="Example text input"
        inputId="exampleId"
        placeholder="Type your example text..."
      />
      <h2>Heading component</h2>
      <Heading text="Heading example text" size={1} />
      <h2>Text</h2>
      <Text content="Examnple content of text" bold fontSize={40} />
      <h2>Currencies table</h2>
      <CurrenciesTable
        currencies={[
          { name: "PLN", price: 4.59 },
          { name: "USD", price: 1.52 },
          { name: "EUR", price: 1.1 },
        ]}
      />
      <h2>Details Modal</h2>
      <button
        type="button"
        className="btn btn-primary"
        data-bs-toggle="modal"
        data-bs-target="#exampleModal"
      >
        Launch demo modal
      </button>
      <DetailsModal
        title="Job salary"
        description="salary with bonuses"
        price={15000}
        currency="PLN"
        date="18 August 2024"
      />
      <h2>Pagination example</h2>
      <Pagination
        pages={[
          { link: "#", label: "1" },
          { link: "#", label: "2" },
          { link: "#", label: "3" },
        ]}
      />
      <h2>Button group example</h2>
      <ButtonGroup
        buttons={[{ label: "first" }, { label: "second" }, { label: "third" }]}
      />
    </div>
  );
}
