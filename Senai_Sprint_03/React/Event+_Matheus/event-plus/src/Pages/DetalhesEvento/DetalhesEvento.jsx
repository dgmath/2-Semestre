import React, { useEffect, useState } from 'react';
import MainContent from '../../Components/MainContent/MainContent';
import Title from '../../Components/Title/Title';
import api from '../../Services/Service';
import { useParams } from 'react-router-dom';








const DetalhesEvento = () => {
    const [comentario, setComentario] = useState([]);
    const [comentarioIa, setComentarioIa] = useState([]);
    const [evento, setEvento] = useState();

    const {idEvento} = useParams()
    useEffect(()=> {
        async function getEventos() {
            try {
                const retornoEvento = await api.get(`/Evento/${idEvento}`)
                const retornoComum = await api.get("/Comentarios");
                const retornoIa = await api.get("/Comentarios/ListarSomenteExibe");
            
                console.log(retornoComum.data);
                console.log(retornoIa.data);
                setComentario(retornoComum.data)
                setComentarioIa(retornoIa.data)
                setEvento(retornoEvento.data)
                console.log(retornoEvento.data);
            } catch (error) {
                alert("deu ruim")
            }
        }
        getEventos()
        
    },[])
    





    
    return (
        <MainContent>
            <Title titleText={"Comentarios do evento"}/>
            <p> id do evento: {idEvento}</p>
            {/* {evento.nomeEvento} */}
        </MainContent>
    );
};

export default DetalhesEvento;