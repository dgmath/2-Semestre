import React from 'react';
import "./FormComponents.css"

export const Select = ({
    required,
    id,
    name,
    options,
    manipulationFunction,
    additionalClass = "",
    defaultValue
}) => {
    return (
        <select 
            name={name} 
            id={id}
            required={required}
            className={`input-component ${additionalClass}`}
            onChange={manipulationFunction}
            value={defaultValue}

        >
            {/* <option value="">Selecione</option> */}
            {options.map((o) =>{
                return (
                    <option key={Math.random()} value={o.value}>{o.text}</option>
                );
            })}
        </select>
    );
}

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