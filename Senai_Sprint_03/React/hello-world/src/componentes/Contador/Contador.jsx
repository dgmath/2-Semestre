import React, { useState } from 'react'
import './Contador.css'

const Contador = () => {

    const [contador, setContador] = useState(0)

    function handleIncrementar() {
        setContador(contador + 1);
    }
    function handleDecrementar() {
        setContador(contador === 0 ? 0 : contador -1 );
    }

    return (
        <>        
        <p>{contador}</p>
        <button onClick={() => {
            handleIncrementar()
        }}>Incrementar</button>
        <br />
        <br />
        <button 
        onClick={() => {
            handleDecrementar()
        }}>Decrementar</button>
        </>
    );
};

export default Contador;