import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  logintitle: string = 'Login';
 
  email: string = '';
  password: string = '';
  rememberMe: boolean = false;

  onSubmit() {
    if (this.email && this.password) {
      // Handle the login logic here
      console.log('Email:', this.email);
      console.log('Password:', this.password);
      console.log('Remember Me:', this.rememberMe);
    }
  }

  constructor() { }

  ngOnInit(): void {
  }

}
