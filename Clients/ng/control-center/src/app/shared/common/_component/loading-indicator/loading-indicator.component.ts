import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoadingService } from '../../_service';

@Component({
  selector: 'app-loading-indicator',
  templateUrl: './loading-indicator.component.html',
  styleUrls: ['./loading-indicator.component.scss']
})
export class LoadingIndicatorComponent implements OnInit {

  constructor(private loadingService: LoadingService) { }

  ngOnInit() {
  }

  get isLoading$(): Observable<boolean> {
    return this.loadingService.isLoading$;
  }

}
