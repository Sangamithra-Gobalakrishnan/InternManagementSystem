import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
  roleStatus: boolean = false;

  @Input() role: string;

  constructor() {
    if (localStorage.getItem('role') == 'Admin') {
      this.roleStatus = true;
    }
  }

  // Update roleStatus when the role value changes
  ngOnChanges() {
    if (this.role == 'Admin') {
      this.roleStatus = true;
    } else {
      this.roleStatus = false;
    }
  }
    
}

 
