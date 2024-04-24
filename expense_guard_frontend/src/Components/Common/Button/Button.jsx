import React from "react";
import "./Button.scss";

function Button({ text, onClick }) {
  return (
    <button className="buttonShape buttonSkin buttonContent" onClick={onClick}>
      {text}
    </button>
  );
}

export default Button;
