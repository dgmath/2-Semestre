import './App.css';
import Rotas from './Routes/routes';
import { useEffect, useState } from 'react';
import { UserContext } from './Context/AuthContext';

function App() {

  const [userData, setUserData] = useState(UserContext)

  useEffect(()=> {
    const token = localStorage.getItem("token")

    setUserData(token === null ? {} : JSON.parse(token))

    // if (token !== null) { setUserData(JSON.parse(token)) }
  },[])





  return (
    <UserContext.Provider value={{userData, setUserData}}>
      <Rotas/>
    </UserContext.Provider>
  );
}

export default App;
