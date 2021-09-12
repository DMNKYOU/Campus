import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { Router } from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //component properties for login
  email: String;
  password: String;
 // declare services needed- if they are not public they can not be used with Heroku
  constructor(
    public authService: AuthService,
    public router: Router,
    public flashMessage: FlashMessagesService
  ) { }

  ngOnInit() {
  }

  onLoginSubmit() {
    //create object user for login
    const user = {
      email: this.email,
      password: this.password,
    }
      
    this.authService.authUser(user).subscribe(data => {
      //  console.log("authService/authUser" + data);
      if (data.success) {
        this.authService.storeUserData(data.token, data.user);
        this.flashMessage.show('You are now logged in!', {
          cssClass: 'alert-success',
          timeout: 6000
        });
        this.router.navigate(['products']);
      }
      else {
        this.flashMessage.show('Login failed! Please try again!', {
          cssClass: 'alert-danger',
          timeout: 6000
        });
        this.router.navigate(['']);
      }
    });

  }
  // for navbar logout
  onLogoutClick() {
    this.authService.logout();
    this.flashMessage.show('You are logged out!', {
      cssClass: 'alert-succes',
      timeout: 3000
    });
    this.router.navigate(['']);
    return false;
  }
}
