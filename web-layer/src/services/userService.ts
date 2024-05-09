import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AddToFavoriteModel } from "../models/addToFavoriteModel";
import { OrderModel } from "../models/orderModel";

@Injectable({ providedIn: "root" })
export class UserService {
    constructor(private client: HttpClient) {

    }

    private path: string = "api/users/";

    getAll(): Observable<any> {
        return this.client.get<any>(this.path);
    }

    getById(id: string): Observable<any> {
        return this.client.get<any>(this.path + id);
    }
    delete(id: string): Observable<any> {
        return this.client.delete(this.path + id);
    }

    isInFavorite(userId: string, carId: string ): Observable<boolean>{
        let params = new HttpParams();

        params = params.append("UserId", userId);
        params = params.append("CarId", carId);

        return this.client.get<any>(this.path + 'favorite', {params});
    }

    addToFavorite(addToFavoriteModel: AddToFavoriteModel): Observable<any>{
        return this.client.put(this.path, addToFavoriteModel);
    }

    order(orderModel: OrderModel): Observable<any>{
        return this.client.post(this.path, orderModel);
    }
}