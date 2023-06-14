import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { RaiseticketComponent } from './raiseticket/raiseticket.component';
import { InternComponent } from './intern/intern.component';
import { TicketComponent } from './ticket/ticket.component';
import { CancelticketComponent } from './cancelticket/cancelticket.component';
import { TicketdetailsComponent } from './ticketdetails/ticketdetails.component';
import { TicketsolutionComponent } from './ticketsolution/ticketsolution.component';
import { AppComponent } from './app.component';
import { LogindetailsComponent } from './logindetails/logindetails.component';

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'ticket',component:TicketComponent},
  {path:'time',component:LogindetailsComponent},
  {path:'ticket/raiseticket',component:RaiseticketComponent},
  {path:'ticket/cancelticket',component:CancelticketComponent},
  {path:'ticket/ticketdetails',component:TicketdetailsComponent},
  {path:'ticket/ticketsolution',component:TicketsolutionComponent},
  {path:'intern',component:InternComponent},
  {path:'',component:RegisterComponent},
  {path:'app',component:AppComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
