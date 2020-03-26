import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadingService } from '../../_service/loading/loading.service';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'app-loading-indicator',
  templateUrl: './loading-indicator.component.html',
  styleUrls: ['./loading-indicator.component.scss']
})
export class LoadingIndicatorComponent implements OnInit {
  isLoading$: Observable<any>;

  constructor(private loadingService: LoadingService) { }

  ngOnInit() {
    this.isLoading$ = this.loadingService.isLoading$;
  }
}
