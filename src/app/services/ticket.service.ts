import { HttpClient, HttpHeaders } from "@angular/common/http";
import {Injectable} from '@angular/core';
import { Observable } from "rxjs";
import { TicketModel } from "src/models/ticket.model";

@Injectable()
export class TicketService{

    constructor(private httpClient:HttpClient){

    }
    createTicket(ticket:TicketModel){
        return this.httpClient.post("http://localhost:5015/api/TicketRaise/Raise Ticket",ticket);
    }
    
    cancelTicket(ticketId:any){
        const url = `http://localhost:5015/api/TicketRaise/Cancel Ticket?TicketID=${ticketId}`;
        return this.httpClient.delete(url);
    }

    getTickets():Observable<any>{
        var header = new HttpHeaders({
         'Content-Type':'application/json',
         'Authorization':'Bearer'+localStorage.getItem("token")?.toString()
        });
        return this.httpClient.get("http://localhost:5015/api/TicketRaise/Available Ticket Details",{headers:header});
        
     }
}