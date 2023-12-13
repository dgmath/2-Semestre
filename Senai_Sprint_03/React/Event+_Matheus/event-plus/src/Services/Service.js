//Configuração para porta da api, sempre que voce for usar voce passa apenas o recurso(url)
import axios from "axios";

const apiPort = "5000";
const localApi = `http://localhost:${apiPort}/api`;
const externalUrlApi = `https://eventmatheus.azurewebsites.net/api`;


const api = axios.create({
    baseURL : localApi
});

export default api;