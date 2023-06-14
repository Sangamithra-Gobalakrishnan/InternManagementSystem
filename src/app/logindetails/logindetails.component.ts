import { Component } from '@angular/core';
import { TimeModel } from 'src/models/time.model';
import { TimeService } from '../services/time.service';

@Component({
  selector: 'app-logindetails',
  templateUrl: './logindetails.component.html',
  styleUrls: ['./logindetails.component.css']
})
export class LogindetailsComponent {
   log:TimeModel[];

  constructor(private timeService:TimeService)
  {
     
  }
    getLog()
    {
      this.timeService.getLog().subscribe(data=> {
        this.log=data as TimeModel[];
        //console.log(this.log);
      });
    }
}
