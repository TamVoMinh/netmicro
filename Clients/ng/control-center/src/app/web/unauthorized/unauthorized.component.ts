import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-unauthorized',
  templateUrl: './unauthorized.component.html',
  styleUrls: ['./unauthorized.component.scss']
})
export class UnauthorizedComponent implements OnInit {

  constructor(private authService: AuthService, private location: Location) { }

  ngOnInit() {
  }

  login() {
    this.authService.login();
  }

  goback() {
    this.location.back();
  }

}
