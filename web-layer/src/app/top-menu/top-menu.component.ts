import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LocalService } from '../../services/localService';
import { BrowserModule } from '@angular/platform-browser';
import { SidebarComponent } from './sidebar/sidebar.component';
import { JwtHelperService } from '@auth0/angular-jwt';
import { decode } from 'punycode';

@Component({
  selector: 'app-top-menu',
  standalone: true,
  imports: [CommonModule, RouterModule, SidebarComponent],
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent implements OnInit {
  constructor(private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private router: Router,
) { }

  isAuthorized: boolean = false;
  isAdmin: boolean = false;
  currentRoute: string = '';

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);

    if (token)
      {
        console.log(token);
        this.isAuthorized = true;
        let decodedData = this.jwtHelperService.decodeToken(token);
        this.isAdmin = decodedData.role == "Admin";
      }
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.currentRoute = event.url;
      }
    });
  }

  onExit() {
    this.isAuthorized = false;
    this.localService.remove(LocalService.AuthTokenName);
    window.location.href = '/login';
  }
}
