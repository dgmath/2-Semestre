import React, { useContext } from 'react';
import './Nav.css'
import { Link } from 'react-router-dom';
import logoMobile from '../../Assets/images/logo-white.svg'
import logoDesktop from '../../Assets/images/logo-pink.svg'
import { UserContext } from '../../Context/AuthContext';

const Nav = ( {setExibeNavbar , exibeNavbar} ) => {

    	const {userData} = useContext(UserContext);


    return (
        <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            <span className='navbar__close' onClick={() => {setExibeNavbar(false)}}>x</span>

            <Link to="/">
                <img
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? logoDesktop : logoMobile } 
                alt="Event Plus logo" 
                />
            </Link>

            <div className='navbar__items-box'>

                {userData.role === "Administrador" ? (
                    <>
                    
                        {/* Administrador */}
                        <Link to="/tipo-evento" className='navbar__item' onClick={() => {setExibeNavbar(false)}}>Tipos de Evento</Link>
                        <Link to="/eventos" className='navbar__item' onClick={() => {setExibeNavbar(false)}}>Eventos</Link>
 
                    </>
                ) : ( userData.role === "Comum" ?
                        (                   
                            <>
                            {/* Aluno */}
                            <Link to="/eventos-aluno" className='navbar__item' onClick={() => {setExibeNavbar(false)}}>Eventos</Link>
                            </>
                        )
                        : (
                            <>
                            {/* Público */}
                            <Link to="/" className='navbar__item' onClick={() => {setExibeNavbar(false)}}>Home</Link>
                            </>
                        )
                        )}



                {/* <Link to="/login" className='navbar__item' onClick={() => {setExibeNavbar(false)}}>Login</Link> */}

            </div>

        </nav>
    );
};

export default Nav;