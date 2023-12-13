import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

//import dos componentes de página
import HomePage from "../Pages/HomePage/HomePage";
import TipoEventoPage from "../Pages/TipoEventoPage/TipoEventoPage";
import EventosPage from "../Pages/EventosPage/EventosPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";
import { PrivateRoute } from "./PrivateRoute";
import EventosAlunoPage from "../Pages/EventosAluno/EventosAlunoPage";
import DetalhesEvento from "../Pages/DetalhesEvento/DetalhesEvento";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />

        <Route
          path="/tipo-evento"
          element={
            // Com o private route criamos um componente que faz uma certa verificação  a olhar dentro do token, caso o token exista então você estará logado sendo assim a rota pode ser vista e usaada, caso não ele te navegara para a rota da qual você definir de forma que neste projeto se você não estiver automaticamente ele te manda para a página home.
            <PrivateRoute redirectTo="/login">
              <TipoEventoPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos"
          element={
            <PrivateRoute redirectTo="/login">
              <EventosPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos-aluno"
          element={
            <PrivateRoute redirectTo="/login">
              <EventosAlunoPage />
            </PrivateRoute>
          }
        />

        <Route 
          path="/detalhes-evento/:idEvento"
          element={<DetalhesEvento />}
        />


        <Route element={<LoginPage />} path="/login" />

        {/* <Route element={<TestPage />} path="/teste-page" /> */}
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
