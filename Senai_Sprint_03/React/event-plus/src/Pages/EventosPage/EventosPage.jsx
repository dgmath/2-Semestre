import React, { useEffect, useState } from "react";
import "./EventosPage.css";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Container from "../../Components/Container/Container";
import { Button, Input, Select } from "../../Components/FormComponents/FormComponents";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import imagemEvento from "../../Assets/images/evento.svg"
import TableE from "./TableE/TableE";
import api from "../../Services/Service";
import Notification from "../../Components/Notification/Notification";

const EventosPage = () => {

  const [nome, setNome] = useState("");
  const [desc, setDesc] = useState("");
  const [tipoEvento, setTipoEvento] = useState([]);
  const [data, setData] = useState();
  const [evento, setEvento] = useState([]);
  const [notifyUser, setNotifyUser] = useState({});


  useEffect(() => {

    async function getEventos() {

      try {
        const retorno = await api.get("/Evento");
        console.log(retorno.data);
        setEvento(retorno.data)
      } catch (error) {
        alert("Deu ruim na api")
      }
    }
    getEventos()
    console.log("A home foi montada")

    async function getTipoEvento() {
      try {
        const retorno = await api.get("/TiposEvento")
        setTipoEvento(retorno.data)
      } catch (error) {
        alert("Deu ruim na api")
      }
    }
    getTipoEvento()
  },[])

  async function getState()
  {
    try {
      const retornoGet = await api.get("/Evento");
      setEvento(retornoGet.data)
    } catch (error) {
      alert("Algo deu Errado")
    }
  }

async function handleDelete(id) {
  try {
    const retorno = await api.delete(`/Evento/${id}`);
    setNotifyUser({
      titleNote: "Sucesso",
      textNote: `Apagado com sucesso!`,
      imgIcon: "success",
      imgAlt:
        "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
      showMessage: true
    }); 
    getState();
  } catch (error) {
    alert("Algo deu errado")
  }
}
async function updateForm() {
  alert("fsad")
}




  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser}/>

      <section className="cadastro-evento-section">
      <Container>
      <div className="cadastro-evento__box">
      <Title titleText={"Cadastro de Eventos"} />

      <ImageIllustrator 
      alterText={"???????"}
      imageRender={imagemEvento}
      />

      <form action="" className="ftipo-evento">

        <Input 
            type={"text"}
            id={"nome"}
            placeholder={"Nome"}
            required={"required"}
            name={"nome"} // usa a propriedade name para postar no formulario
            value={nome}
            manipulationFunction={
              (e) => {
                setNome(e.target.value)
              }
            }
        />

        <Input 
            type={"text"}
            id={"desc"}
            placeholder={"Descrição"}
            required={"required"}
            name={"desc"} // usa a propriedade name para postar no formulario
            value={desc}
            manipulationFunction={
              (e) => {
                setDesc(e.target.value)
              }
            }
        />
        
        <select name="" id=""> <option value="Evento">Tipo Evento</option></select>

        {/* <Select 
            name={"tipoEvento"} 
            id={"tipoEvento"}
            required={"required"}
            onChange={"manipulationFunction"}
            value={"tipoEvento"}
        > */}
   

        <Input 
            type={"date"}
            id={"data"}
            required={"required"}
            name={"data"} // usa a propriedade name para postar no formulario
            value={data}
            manipulationFunction={
              (e) => {
                setData(e.target.value)
              }
            }
        />

        <Button 
            type={"submit"}
            id={"botao"}
            name={"button"}
            textButton={"Cadastrar"}
        />
      </form>

      </div>
      </Container>

      </section>

      <section className="lista-eventos-section">
          <Container>

            <Title  titleText={"Lista de Eventos"} color="white" />
            <TableE 
              dados={evento}
              fnUpdate={updateForm}
              fnDelete={handleDelete}
            />
            
          </Container>
      </section>

    </MainContent>

    //tipo evento listagem do que foi cadastrado select, preencher duas variavei, no mesmo use effect dois gets tipo evento e eventos faltara um campo na api tipo evento, state para tipo evento, get get para instituicao tambem e guarda-los dentro do state, tres get em um try



  );
};

export default EventosPage;
