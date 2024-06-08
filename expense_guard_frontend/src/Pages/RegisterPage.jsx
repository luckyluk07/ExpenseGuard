import React from "react";
import RegisterForm from "../Components/Account/RegisterForm";
import { setToken } from "../Components/Services/General/tokenService";

export default function RegisterPage() {
  return (
    <div>
      <h1>Register page</h1>
      <RegisterForm
        onDone={(responseObject) => {
          setToken(responseObject.value);
        }}
      />
    </div>
  );
}
