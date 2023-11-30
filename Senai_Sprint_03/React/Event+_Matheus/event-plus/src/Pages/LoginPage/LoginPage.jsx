import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import logo from "../../Assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import loginImage from "../../Assets/images/login.svg"
import api from "../../Services/Service";
import { UserContext, userDecodeToken } from "../../Context/AuthContext";
import "./LoginPage.css";
import { useNavigate } from "react-router-dom";



const LoginPage = () => {
  
const [user, setUser] = useState({email: "cat@comum.com", senha: "123456789"})
//dados globais do usuario
const {userData, setUserData} = useContext(UserContext)
const navigate = useNavigate()

useEffect(() => {
  if(userData.name) {navigate("/")}
},[userData])

async function handleSubmit(e) {
  e.preventDefault();

  if (user.email.length >= 3 && user.senha.length >= 3) {
    //chamar a api
    try {
      const retorno = await api.post("/Login", {
        email: user.email,
        senha: user.senha
      });

      // console.log(retorno.data.token);

      const userFullToken = userDecodeToken(retorno.data.token);

      setUserData(userFullToken);
      localStorage.setItem("token", JSON.stringify(userFullToken));
      navigate("/")
      console.log(userData);


    } catch (error) {
      alert("Usuário ou senha incorretos. Por favor tente novamente")
    }
  }
  else{
    alert("É preciso ter mais de duas caracteres, preencha os campos corretamente!")
  }
}

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({ 
                  ...user,//restOperator
                  email: e.target.value.trim() })
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({ 
                  ...user,//restOperator
                  senha: e.target.value.trim() })
              }}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
