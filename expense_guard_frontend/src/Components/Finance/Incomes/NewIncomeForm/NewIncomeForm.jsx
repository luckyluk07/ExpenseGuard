import React from "react";
import TextInput from "../../../Forms/TextInput/TextInput";

function NewIncomeForm() {
  return (
    <div className="container my-5">
      <h3>New income form</h3>
      <div className="w-50">
        <TextInput labelText="Name" placeholder="eg. Salary" />
        <TextInput labelText="Amount" placeholder="eg. 255.5" />
      </div>
    </div>
  );
}

export default NewIncomeForm;
