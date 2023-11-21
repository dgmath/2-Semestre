import React from 'react';
import "./FormComponents.css"


export const Input = ({
    type,
    id,
    required,
    value,
    additionalClass ="",
    name,
    placeholder,
    manipulationFunction
}) => {
    return(
        <input 
        type={type}
        id={id} 
        value={value}
        required={required}
        className={`input-component ${additionalClass}`}
        name={name}
        placeholder={placeholder}
        onChange={manipulationFunction}
        autoComplete='off'
         />
    );
};

export const Button = ({
    textButton,
    id,
    name,
    type,
    additionalClass = "",
    manipulationFunction

    }) => {
        return (
            <button 
                id={id}
                name={name}
                type={type}
                className={`button-component ${additionalClass}`}
                onClick={manipulationFunction}
            >
                {textButton}
            </button>
        )
}