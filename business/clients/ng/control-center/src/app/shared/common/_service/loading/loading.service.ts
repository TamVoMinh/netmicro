import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private loadingSubject = new BehaviorSubject<boolean>(false);
  isLoading$: Observable<boolean>;
  constructor() {
    this.isLoading$ = this.loadingSubject.asObservable();
  }

  show() {
     this.loadingSubject.next(true);
  }

  hide() {
    this.loadingSubject.next(false);
  }
}
