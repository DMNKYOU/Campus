import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../app/shared/auth.service';
import { Router } from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  constructor(
    public authService: AuthService,
    public router: Router,
    public flashMessage: FlashMessagesService
  ) { }

  ngOnInit() {
  }
}
