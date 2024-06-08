import React from "react";
import LoginForm from "../Components/Account/LoginForm";
import { setToken } from "../Components/Services/General/tokenService";

export default function LoginPage() {
  return (
    <div>
      <h1>Login page</h1>
      <LoginForm
        onDone={(responseObject) => {
          console.log("response object from login", responseObject);
          setToken(responseObject.value);
        }}
      />
    </div>
  );
}
