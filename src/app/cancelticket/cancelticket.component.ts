import { Component } from '@angular/core';
import { TicketService } from '../services/ticket.service';
import { LoggedInUserModel } from 'src/models/loggedinuser.model';

@Component({
  selector: 'app-cancelticket',
  templateUrl: './cancelticket.component.html',
  styleUrls: ['./cancelticket.component.css']
})
export class CancelticketComponent {
    ticketID:any;
    loggedInUser:LoggedInUserModel;
    constructor(private ticketService:TicketService){
      
    }
    
    cancelTicket(){
      this.ticketService.cancelTicket(this.ticketID).subscribe((data)=>{
        this.loggedInUser = data as any;
        localStorage.setItem("token",this.loggedInUser.token);
        console.log(this.loggedInUser);
      },
      err=>{
        console.log(err)
      });
    }
}
