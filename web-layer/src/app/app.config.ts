import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { RouterModule, provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { LocalService } from '../services/localService';
import { jwtFactory } from './jwt-options';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AuthService } from '../services/authService';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { adminRoutes } from './admin/admin.router';
import { errorInterceptor } from '../interceptor/errorHandlingInterceptor';


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideRouter(adminRoutes),
    provideClientHydration(),
    provideHttpClient(
      withInterceptors([errorInterceptor]),
    ),
    importProvidersFrom([
      FormsModule,
      RouterModule,
      HttpClientModule,
      BrowserModule,
      JwtModule.forRoot({
        jwtOptionsProvider: {
          provide: JWT_OPTIONS,
          useFactory: jwtFactory,
          deps: [LocalService]
        }
      }),
    ])
  ]
};