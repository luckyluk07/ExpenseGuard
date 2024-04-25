import React from "react";

function Text({ content, fontSize, bold }) {
  return (
    <p className={bold ? "fw-bold" : ""} style={{ fontSize: `${fontSize}px` }}>
      {content}
    </p>
  );
}

export default Text;
