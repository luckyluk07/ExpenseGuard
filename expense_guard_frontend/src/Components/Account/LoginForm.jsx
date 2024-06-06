import React, { useState } from "react";
import TextInput from "../Forms/TextInput/TextInput";
import { postApiRequest } from "../Services/Api/makePostApiRequest";
import apiUrls from "../../Shared/apiUrls";
import PasswordInput from "../Forms/PasswordInput";

function LoginForm({ onDone }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  return (
    <div className="container my-5">
      <h3>Login form</h3>
      <div className="w-50 mx-auto p-3 border border-dark rounded">
        <form>
          <TextInput
            labelText="Email"
            placeholder="john@doe.com"
            value={email}
            onChange={(newName) => setEmail(newName)}
          />
          <PasswordInput
            labelText="Password"
            placeholder=""
            value={password}
            onChange={(newName) => setPassword(newName)}
          />
          <button
            type="submit"
            onClick={async (event) => {
              const data = {
                email,
                password,
              };
              const responseObject = await postApiRequest(apiUrls.login, data);
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

export default LoginForm;
