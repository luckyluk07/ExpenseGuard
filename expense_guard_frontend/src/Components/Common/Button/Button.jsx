import React from "react";
import "./Button.css";

function Button({ text, onClick }) {
  return (
    <button className="buttonShape buttonSkin buttonContent" onClick={onClick}>
      {text}
    </button>
  );
}

export default Button;
