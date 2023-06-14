import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterService } from './services/register.service';
import { LoginService } from './services/login.service';
import { InternComponent } from './intern/intern.component';
import { InternService } from './services/intern.service';
import { RaiseticketComponent } from './raiseticket/raiseticket.component';
import { TicketComponent } from './ticket/ticket.component';
import { CancelticketComponent } from './cancelticket/cancelticket.component';
import { TicketdetailsComponent } from './ticketdetails/ticketdetails.component';
import { TicketsolutionComponent } from './ticketsolution/ticketsolution.component';
import { TicketService } from './services/ticket.service';
import { SolutionService } from './services/solution.service';
import { LogindetailsComponent } from './logindetails/logindetails.component';
import { TimeService } from './services/time.service';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    InternComponent,
    RaiseticketComponent,
    TicketComponent,
    CancelticketComponent,
    TicketdetailsComponent,
    TicketsolutionComponent,
    LogindetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [RegisterService,LoginService,InternService,TicketService,SolutionService,TimeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
