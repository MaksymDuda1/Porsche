import { Injectable } from "@angular/core";
import { LoginModel } from "../models/auth/loginModel";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { RegistrationModel } from "../models/auth/registrationModel";

@Injectable({ providedIn: "root" })
export class AuthService {
    constructor(private client: HttpClient) {

    }

    private path: string = "api/auth/";

    login(loginModel: LoginModel): Observable<string> {
        return this.client.post(this.path + 'login', loginModel, { responseType: 'text' });
    }

    register(registrationModel: RegistrationModel): Observable<string> {
        return this.client.post(this.path + 'registration', registrationModel, { responseType: 'text' });
    }

}