import React from 'react';
import './TestPage.css'
import Input from '../../Components/Input/Input';
import Button from '../../Components/Button/Button';
import Header from '../../Components/Header/Header';

const TestPage = () => {
    return (
        <>
        <Header />
        
        <h1>Página de Testes</h1>
        <h2>Calculator</h2>
        <form>
            <Input />
            <br /> <br />
            <Input />
            <br /> <br />
            <Button />
        </form>
        </>
    );
};

export default TestPage;