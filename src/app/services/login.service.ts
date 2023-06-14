import { HttpClient } from "@angular/common/http";
import {Injectable} from '@angular/core';
import { LogModel } from "src/models/log.model";
import { LoginModel } from "src/models/login.model";

@Injectable()
export class LoginService{

    constructor(private httpClient:HttpClient){

    }
    loginIntern(login:LoginModel){
        return this.httpClient.post("http://localhost:5071/api/UserRegister/Login",login);
    }

    changePassword(login:LoginModel){
        return this.httpClient.put("http://localhost:5071/api/Login/Change Password",login);
    }

    addInTime(user:LogModel){
        return this.httpClient.post("http://localhost:5071/api/Login/LogIn Time",user);
    }

    
    addOutTime(user:LogModel){
        return this.httpClient.put("http://localhost:5071/api/Login/LogOut Time",user);
    }
}