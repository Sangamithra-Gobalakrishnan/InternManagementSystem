import { Component } from '@angular/core';
import { InternService } from '../services/intern.service';
import { InternModel } from 'src/models/intern.model';

@Component({
  selector: 'app-intern',
  templateUrl: './intern.component.html',
  styleUrls: ['./intern.component.css']
})
export class InternComponent {
  interns:InternModel[];

  constructor(private internService:InternService)
  {
     
  }
    getInterns()
    {
      this.internService.getInterns().subscribe(data=> {
        this.interns=data as InternModel[];
        console.log(this.interns);
      });
    }

    changeStatus(id:number){
      this.internService.changeStatus(id).subscribe((data)=> {
      })
    }
}


