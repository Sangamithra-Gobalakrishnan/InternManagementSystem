import { Component } from '@angular/core';
import { TicketService } from '../services/ticket.service';

@Component({
  selector: 'app-ticketdetails',
  templateUrl: './ticketdetails.component.html',
  styleUrls: ['./ticketdetails.component.css']
})
export class TicketdetailsComponent {
   tickets:any;

  constructor(private ticketService:TicketService)
  {
    
  }
    getTickets()
    {
      this.ticketService.getTickets().subscribe((data)=> {
        this.tickets=data;
      })
      
    }
}
