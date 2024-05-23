import React from "react";
import Heading from "../Components/Common/Heading/Heading";
import CurrenciesTable from "../Components/Finance/CurrenciesTable/CurrenciesTable";
import DetailsModal from "../Components/Finance/DetailsModal/DetailsModal";
import Text from "../Components/Common/Text/Text";

export default function ComponentsPreview() {
  return (
    <div className="container">
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
    </div>
  );
}
