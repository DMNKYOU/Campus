import { Component, OnInit } from '@angular/core';
import { ValidateService } from '../shared/validate.service';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AuthService } from '../shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  //declare variables needed 
  name: String;
  username: String;
  email: String;
  password: String;
  address: String;
  city: String;
  country: String;
  zip: String;
  // declare services needed
  constructor(
    public validateService: ValidateService,
    public authService: AuthService,
    public flashMessagesService: FlashMessagesService,
    public router: Router
  ) { }
  ngOnInit() {
  }
  onRegisterSubmit() {
    const user = {
      name: this.name,
      email: this.email,
      username: this.username,
      password: this.password,
      address: this.address,
      city: this.city,
      country: this.country,
      zip: this.zip
    }
    //required fields
    if (!this.validateService.validateRegister(user)) {
      this.flashMessagesService.show('Please fill all the fields!', { cssClass: 'alert-danger', timeout: 4000 });
      return false;
    }
    //validate email
    if (!this.validateService.validateEmail(user.email)) {
      this.flashMessagesService.show('Please use a valid email address!', { cssClass: 'alert-danger', timeout: 4000 });
      return false;
    }
    //register user
    this.authService.registerUser(user).subscribe(data => {
      if (data.success) {
        this.flashMessagesService.show('You are now registered and can log in!', { cssClass: 'alert-success', timeout: 4000 });
        this.router.navigate(['/products']);
      }
      else {
        this.flashMessagesService.show('Something went wrong! Plase try again!', { cssClass: 'alert-danger', timeout: 4000 });
        this.router.navigate(['/register']);
      }
    });
  }
}
