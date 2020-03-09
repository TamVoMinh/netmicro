import { Component, OnInit, EventEmitter, Output, Input, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { NbThemeService } from '@nebular/theme';
import { map, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();
  @Input() isAuthorized$: Observable<boolean>;
  @Output() toggle = new EventEmitter<any>();
  @Output() logout = new EventEmitter<any>();
  @Output() login = new EventEmitter<any>();
  currentTheme = 'default';
  themes = [
    {
      value: 'default',
      name: 'Light',
    },
    {
      value: 'dark',
      name: 'Dark',
    },
    {
      value: 'cosmic',
      name: 'Cosmic',
    },
    {
      value: 'corporate',
      name: 'Corporate',
    },
  ];

  constructor(private themeService: NbThemeService) { }

  ngOnInit() {
    this.currentTheme = this.themeService.currentTheme;
    this.themeService.onThemeChange().pipe(
      map(({name}) => name),
      takeUntil(this.destroy$)
    )
    .subscribe(themeName => this.currentTheme = themeName);
  }

  toggleSideNav() {
    this.toggle.emit();
  }

  changeTheme(themeName) {
    this.themeService.changeTheme(themeName);
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
