import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

//import dos componentes de página
import HomePage from './Pages/HomePage/HomePage';
import TipoEventoPage from './Pages/TipoEventoPage/TipoEventoPage';
import EventosPage from './Pages/EventosPage/EventosPage';
import LoginPage from './Pages/LoginPage/LoginPage';
import TestPage from './Pages/TestPage/TestPage';

const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                    <Route element={<HomePage />} path='/' exact/> 
                    <Route element={<TipoEventoPage />} path='/tipo-evento' /> 
                    <Route element={<EventosPage />} path='/eventos' /> 
                    <Route element={<LoginPage />} path='/login' />                     
                    <Route element={<TestPage />} path='/teste-page' />                     
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;