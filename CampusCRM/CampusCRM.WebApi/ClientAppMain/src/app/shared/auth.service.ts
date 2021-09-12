import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { tokenNotExpired } from 'angular2-jwt';

@Injectable()
export class AuthService {

  authToken: any;
  user: any;
  isDev: boolean;

  constructor(
    private http: Http
  ) {
    this.isDev = false;
  }

  //subscribe to observable
  registerUser(user) {
    //  console.log("register user" + user);
    let headers = new Headers();  //new headers
    headers.append('Content-Type', 'application/json'); 
    let ep = this.prepEndpoint('users/register');
    return this.http.post(ep, user, { headers: headers }) //post method 
      .map(res => res.json());
  }

  //auth a user
  authUser(user) {
    // console.log("auth user" + user);
    // console.log("auth data" + user.data);
    let headers = new Headers(); //create new  headers
    headers.append('Content-Type', 'application/json');
    let ep = this.prepEndpoint('users/authenticate');
    return this.http.post(ep, user, { headers: headers }) //post method
      .map(res => res.json());
  }

  //get profile of a user (if is authorizated)
  getProfile() {
    let headers = new Headers();
    this.loadToken(); // stored token in local storage 
    headers.append('Authorization', this.authToken);
    headers.append('Content-Type', 'application/json');
    let ep = this.prepEndpoint('users/profile');
    return this.http.get(ep, { headers: headers }) //get method because we want to take data from db 
      .map(res => res.json());
  }

  //store data of users as JSON
  storeUserData(token, user) {
    localStorage.setItem('id_token', token);
    localStorage.setItem('user', JSON.stringify(user));
    this.authToken = token;
    this.user = user;
  }

  //store token
  loadToken() {
    const token = localStorage.getItem('id_token');
    this.authToken = token;
  }

  //store token for keep user loggin for certain amount of time
  loggedIn() {
    return tokenNotExpired('id_token');
  }

  //clear local storage -> logout
  logout() {
    this.authToken = null;
    this.user = null;
    localStorage.clear();
  }

  //endpoint of server part
  prepEndpoint(ep) {
    if (this.isDev) {
      return ep;
    } else {
      return 'https://immense-reef-59951.herokuapp.com/' + ep;
    }
  }

}
