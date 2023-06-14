import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TicketModel } from 'src/models/ticket.model';
import { TicketService } from '../services/ticket.service';
import { LoggedInUserModel } from 'src/models/loggedinuser.model';

@Component({
  selector: 'app-raiseticket',
  templateUrl: './raiseticket.component.html',
  styleUrls: ['./raiseticket.component.css']
})
export class RaiseticketComponent {
ticket:TicketModel;
myForm:FormGroup;
loggedInUser:LoggedInUserModel;
priority:any;
category:any;

  constructor(private ticketService:TicketService){
    this.ticket = new TicketModel();
    this.loggedInUser = new LoggedInUserModel();

  }

  addPriority(priority:any){
    this.ticket.priority = priority;
  }


  addCategory(category:any){
    this.ticket.category = category;
  }
  raiseTicket(){
    this.ticketService.createTicket(this.ticket).subscribe((data)=>{
      this.loggedInUser = data as LoggedInUserModel;
      localStorage.setItem("token",this.loggedInUser.token);
      console.log(this.loggedInUser);
    },
    err=>{
      console.log(err)
    });
  }
}

