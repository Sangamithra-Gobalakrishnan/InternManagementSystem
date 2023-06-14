import { Component, EventEmitter, Output } from '@angular/core';
import { LoginModel } from 'src/models/login.model';
import { LoginService } from '../services/login.service';
import { LoggedInUserModel } from 'src/models/loggedinuser.model';
import { UserModel } from 'src/models/user.model';
import { LogModel } from 'src/models/log.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    login:LoginModel
    loggedInUser:LoggedInUserModel
    logUser:UserModel
    time:LogModel
    @Output() roleChanged = new EventEmitter<string>();

     constructor(private loginService:LoginService){
        this.login = new LoginModel(); 
        this.loggedInUser = new LoggedInUserModel();
        this.logUser = new UserModel();
        this.time = new LogModel();
     }

     loginCall(){
      this.loginService.loginIntern(this.login).subscribe((data)=>{
      
      this.loggedInUser = data as LoggedInUserModel;
      localStorage.setItem("token",this.loggedInUser.token);
      if(this.loggedInUser.token!=null)
      {
          console.log(this.loggedInUser.role);
          this.roleChanged.emit(this.loggedInUser.role);
      }
      
    },
    err=>{
      console.log(err);
    });
    }
    
    changePassword(){
      this.loginService.changePassword(this.login).subscribe((data)=>{
      this.logUser = data as UserModel;
      //console.log(this.logUser); 
    },
    err=>{
      console.log(err);
    });
  }

  inCall(id:any){
     this.time.UserId = id;
     this.loginService.addInTime(this.time).subscribe((data)=>{
      this.time = data as LogModel;
      //console.log(this.time);
     },
     err=>{
      console.log(err);
     });
  }

  outCall(id:any){
      this.time.UserId = id;
      this.loginService.addOutTime(this.time).subscribe((data)=>{
      this.time = data as LogModel;
      //console.log(this.time);
      },
      err=>{
      console.log(err);
      });
    }
}

