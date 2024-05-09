import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({providedIn: "root"})
export class PorscheCenterService{
    constructor(private client: HttpClient){}

    private path: string = "api/centers/";

    getAll(): Observable<any>{
        return this.client.get<any>(this.path);
    }

    getById(id: string): Observable<any>{
        return this.client.get<any>(this.path + id);
    }

    create(createCenterModel: FormData): Observable<any>{
        return this.client.post(this.path, createCenterModel);
    }

    update(updateCenterModel: FormData): Observable<any>{
        return this.client.put(this.path, updateCenterModel);
    }

    delete(id: string): Observable<any>{
        return this.client.delete(this.path + id);
    }
}