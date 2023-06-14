import { Component, EventEmitter, Output} from '@angular/core';
import { InternModel } from 'src/models/intern.model';
import { LoggedInUserModel } from 'src/models/loggedinuser.model';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

intern:InternModel
loggedInUser:LoggedInUserModel
dateOfBirth: string;
age: number;
showStatus:boolean;


constructor(private internRegisterService : RegisterService,private route:Router){
  this.showStatus = false;
  this.intern = new InternModel();
  this.loggedInUser = new LoggedInUserModel();
}

addGender(gender:any){
  this.intern.gender = gender;
}

addIntern(){
      this.internRegisterService.createIntern(this.intern).subscribe((data)=>{
        this.loggedInUser = data as LoggedInUserModel;
        localStorage.setItem("token",this.loggedInUser.token); 
        if(this.loggedInUser.token!=null)
        {
            this.showStatus = true;
            this.route.navigate(["ticket"]);  
        }
    },
    err=>{
      console.log(err)
    });
}

calculateAge(){
  const today = new Date();
  const birthDate = new Date(this.intern.dateOfBirth);
  var age = today.getFullYear() - birthDate.getFullYear();
  const monthDiff = today.getMonth() - birthDate.getMonth();
  if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
    age--;
  }
  this.intern.age = age;
}
}