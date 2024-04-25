import React from "react";
import styles from "./Button.module.scss";

function Button({ text, onClick }) {
  return (
    <button
      type="button"
      className={`${styles.buttonShape} ${styles.buttonSkin} ${styles.buttonConent}`}
      onClick={onClick}
    >
      {text}
    </button>
  );
}

export default Button;
