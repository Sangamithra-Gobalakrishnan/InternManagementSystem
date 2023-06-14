import { HttpClient } from "@angular/common/http";
import {Injectable} from '@angular/core';
import { InternModel } from "src/models/intern.model";

@Injectable()
export class RegisterService{

    constructor(private httpClient:HttpClient){

    }
    createIntern(intern:InternModel){
        return this.httpClient.post("http://localhost:5071/api/UserRegister/Register",intern);
    }
}