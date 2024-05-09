import { HttpClient } from "@angular/common/http";
import { identifierName } from "@angular/compiler";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {  ChangeRoleModel } from "../models/changeRoleModel";

@Injectable({providedIn: "root"})
export class AdminService{
    constructor(private client: HttpClient){}

    private path = 'api/admin/';

    changeRole(id: ChangeRoleModel): Observable<any>{
        return this.client.put<any>(this.path, id);
    }
}