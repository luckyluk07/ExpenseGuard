import React, { useState } from "react";
import TextInput from "../Forms/TextInput/TextInput";
import { postApiRequest } from "../Services/Api/makePostApiRequest";
import apiUrls from "../../Shared/apiUrls";
import PasswordInput from "../Forms/PasswordInput";

function RegisterForm({ onDone }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [repeatedPassword, setRepeatedPassword] = useState("");

  return (
    <div className="container my-5">
      <h3>Register form</h3>
      <div className="w-50 mx-auto p-3 border border-dark rounded">
        <form>
          <TextInput
            labelText="Email"
            placeholder="john@doe.com"
            value={email}
            onChange={(newName) => setEmail(newName)}
          />
          <PasswordInput // todo variant of textInput with password
            labelText="Password"
            placeholder=""
            value={password}
            onChange={(newName) => setPassword(newName)}
          />
          <PasswordInput
            labelText="Repeat your password"
            placeholder=""
            value={repeatedPassword}
            onChange={(newName) => setRepeatedPassword(newName)}
          />
          <button
            type="submit"
            onClick={(event) => {
              if (password !== repeatedPassword) {
                return;
              }
              const data = {
                email,
                password,
                repeatPassword: repeatedPassword,
              };
              const responseObject = postApiRequest(apiUrls.register, data);
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

export default RegisterForm;
