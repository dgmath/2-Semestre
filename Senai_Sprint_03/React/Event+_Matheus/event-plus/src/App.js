import './App.css';
import Rotas from './routes';
import {  useState } from 'react';
import { UserContext } from './Context/AuthContext';

function App() {

  const [userData, setUserData] = useState(UserContext)

  return (
    <UserContext.Provider value={{userData, setUserData}}>
      <Rotas/>
    </UserContext.Provider>
  );
}

export default App;
