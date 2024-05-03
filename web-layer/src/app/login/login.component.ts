import { Component } from '@angular/core';
import { AuthService } from '../../services/authService';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from '../../models/auth/loginModel';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  constructor(private authService: AuthService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService
  ) { }

  loginModel = new LoginModel();
  errorMessage = "";

  onLogin(){
    this.authService.login(this.loginModel).subscribe(data => {
      this.localService.put(LocalService.AuthTokenName, data);
        let decodedData = this.jwtHelperService.decodeToken(data);

        if(decodedData.role == "Admin")
          window.location.href = '/admin';
        else
          window.location.href = '/';
    },
    errorResponse => {
      this.errorMessage = errorResponse.error;
    })
  }
}
