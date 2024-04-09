import React from 'react';
import './Button.css'; 

function Button(props) {
  return (
    <button className='buttonShape buttonSkin buttonContent' onClick={props.onClick}>{props.text}</button>
  );
}

export default Button;