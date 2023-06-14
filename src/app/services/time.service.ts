import { HttpClient, HttpHeaders } from "@angular/common/http";
import {Injectable} from '@angular/core';
import { Observable } from "rxjs";
import { TicketModel } from "src/models/ticket.model";

@Injectable()
export class TimeService{

    constructor(private httpClient:HttpClient){

    }
   
    getLog(){
        var header=new HttpHeaders({
              'Content-Type':'application/json',
              'Authorization':'Bearer '+localStorage.getItem("token")?.toString()
        });
         return this.httpClient.get("http://localhost:5071/api/Filter/Get All Log Details",{headers:header});
      }
}