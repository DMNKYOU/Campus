import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Injectable()
export class AuthGuardService implements CanActivate {
  // declare services needed
  constructor(
    public authService: AuthService,
    public router: Router
  ) { }

  canActivate() {
    if (this.authService.loggedIn()) { // can have access to more components than if you`re not loogedIn
      return true;
    } else {
      this.router.navigate(['']); // it will just redirect you to the main component(HomeComponent)
      return false;
    }
  }
}
