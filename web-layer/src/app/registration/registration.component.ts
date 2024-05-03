import { Component } from '@angular/core';
import { AuthService } from '../../services/authService';
import { RegistrationModel } from '../../models/auth/registrationModel';
import { LocalService } from '../../services/localService';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule, HttpClientModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  constructor(private authService: AuthService,
    private localService: LocalService
  ) {

  }

  registrationModel: RegistrationModel = new RegistrationModel();
  errorMessage: string = "";

  onRegistration() {
    this.authService.register(this.registrationModel).subscribe(data => {
      this.localService.put(LocalService.AuthTokenName, data);
      window.location.href = '/';
    },
      errorResponse => this.errorMessage = errorResponse.error)
  }
}
