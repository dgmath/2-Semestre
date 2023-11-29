import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

export const UserContext = createContext({});

export const userDecodeToken= (theToken) => {
    const decoded = jwtDecode(theToken);//retona o payload
    
    return{ 
        role: decoded.role,
        name: decoded.name,
        userId: decoded.jti,
        token: theToken
    }
}