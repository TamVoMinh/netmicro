import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  constructor(private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.initAuth();
  }

  ngOnDestroy() {
    this.authService.ngOnDestroy();
  }
}
