import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { filter } from 'rxjs/operators';
import { LoadingService } from '@shared/common/_service/loading/loading.service';
import { Store, select } from '@ngrx/store';
import { IAppState } from '../store/states/app.state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  constructor(
    private authService: AuthService,
    private loadingService: LoadingService,
    private router: Router,
    ) {
  }

  ngOnInit() {
    this.authService.initAuth();
    this.router.events
    .pipe(
      filter(
        event => event instanceof NavigationStart ||
                 event instanceof NavigationEnd ||
                 event instanceof NavigationCancel ||
                 event instanceof NavigationError )
    )
    .subscribe(event => {
      if(event instanceof NavigationStart) {
        this.loadingService.show();
        return;
      }
      this.loadingService.hide();
    })
  }

  ngOnDestroy() {
    this.authService.ngOnDestroy();
  }
}
