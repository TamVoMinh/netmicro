import { Component, OnInit } from '@angular/core';
import { NbThemeService } from '@nebular/theme';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private themeService: NbThemeService
   ) { }

  ngOnInit() {
  }

  changeThemes() {
    this.themeService.changeTheme('cosmic');
  }

}
