import { Component } from '@angular/core';
import { SolutionModel } from 'src/models/solution.model';
import { SolutionService } from '../services/solution.service';
import { LoggedInUserModel } from 'src/models/loggedinuser.model';

@Component({
  selector: 'app-ticketsolution',
  templateUrl: './ticketsolution.component.html',
  styleUrls: ['./ticketsolution.component.css']
})

export class TicketsolutionComponent {
  solution:SolutionModel;
  loggedInUser:LoggedInUserModel;
    constructor(private solutionService:SolutionService){
        this.solution = new SolutionModel();
        this.loggedInUser = new LoggedInUserModel();
    }

    provideSolution(){
      this.solutionService.provideSolution(this.solution).subscribe((data)=>{
      
      this.loggedInUser = data as LoggedInUserModel;
      localStorage.setItem("token",this.loggedInUser.token);
      console.log(this.loggedInUser);
    },
    err=>{
      console.log(err)
    });
    }
}
