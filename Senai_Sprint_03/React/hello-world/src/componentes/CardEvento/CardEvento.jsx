import React from "react";
import './CardEvento.css';

const CardEvento = ({ titulo, texto, desabilitar, textoLink }) => {
    return(
        <div className="card-evento">
            <h1 className="card-evento__title">{titulo}</h1>
            <p className="card-evento__text">{texto}</p>
            <button 
            className={desabilitar ? "card-evento__conect card-evento__conect--disable" : "card-evento__conect"}
            >{textoLink}
            </button>
        </div>
    );
};

export default CardEvento;