import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/common/_service/auth/auth.service';
import { Observable } from 'rxjs';
import { LoadingService } from '@app/shared/common';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  isLoading$: Observable<boolean>;
  constructor(
    private authService: AuthService,
    private loadingService: LoadingService,
    private router: Router
    ) {
  }

  ngOnInit() {
    this.authService.initAuth();
    this.isLoading$ = this.loadingService.isLoading$;
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
