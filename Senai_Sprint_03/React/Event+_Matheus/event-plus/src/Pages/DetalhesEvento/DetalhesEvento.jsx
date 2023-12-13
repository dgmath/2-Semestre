import React, { useEffect, useState } from 'react';
import MainContent from '../../Components/MainContent/MainContent';
import Title from '../../Components/Title/Title';
import api from '../../Services/Service';
import { useParams } from 'react-router-dom';




// const [comentario, setComentario] = useState([]);
// const [comentarioIa, setComentarioIa] = useState([]);



const DetalhesEvento = () => {

    const {idEvento} = useParams()
    useEffect(()=> {
        // const retornoComum = api.get("/Comentarios");
        // const retornoIa = api.get("/Comentarios/ListarSomenteExibe");
    
        // console.log(retornoComum.data);
        // console.log(retornoIa.data);
        // setComentario(retornoComum.data)
        // setComentarioIa(retornoIa.data)
        // console.log(retornoEvento.data);
        // setEvento(retornoEvento.data)
    },[])
    
    const [evento, setEvento] = useState([]);




    
    return (
        <MainContent>
            <Title titleText={"Comentarios do evento"}/>
            <p> id do evento: {idEvento}</p>
        </MainContent>
    );
};

export default DetalhesEvento;