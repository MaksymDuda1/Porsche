import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AdminRoutingModule } from './admin.router';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent implements OnInit {
  constructor(private localService: LocalService,
    private jwtHelperService: JwtHelperService
  ) {

  }

  isAdmin = false;
  errorMessage: string = '';


  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);

    if (token) {
      let decodedToken = this.jwtHelperService.decodeToken(token);
      if (decodedToken.role = "Admin")
        this.isAdmin = true;

      else
        this.errorMessage = "You are unauthorized"
    }
    else
      this.errorMessage = "Path not allowed"

  }
}
