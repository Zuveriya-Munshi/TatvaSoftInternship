import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registertitle = 'Registeration Form';
 
  email: string = '';
  password: string = '';
  rememberMe: boolean = false;
  loading: boolean = false;


  onRegister() {
    if (this.email && this.password) {
      this.loading = true;
      setTimeout(() => {
        // Handle the register logic here
        console.log('Email:', this.email);
        console.log('Password:', this.password);
        console.log('Remember Me:', this.rememberMe);

        // Stop the loading spinner
        this.loading = false;
      }, 2000);
    }
  }

  constructor() { }

  ngOnInit(): void {
  }

}
