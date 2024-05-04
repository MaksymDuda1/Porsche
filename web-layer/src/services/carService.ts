import { Injectable } from "@angular/core";
import { PhotoModel } from "../models/photoModel";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CarModel } from "../models/CarModel";
import { UpdateCarModel } from "../models/UpdateCarModel";

@Injectable({ providedIn: "root" })
export class CarService {
    constructor(private client: HttpClient) {

    }

    private path: string = "api/cars/";

    getAllCars(): Observable<CarModel[]> {
        return this.client.get<any>(this.path);
    }

    getById(id: string): Observable<CarModel> {
        return this.client.get<CarModel>(this.path + id);
    }

    createCar(carModel: CarModel): Observable<any> {
        return this.client.post(this.path, carModel);
    }

    updateCar(updateCarModel: UpdateCarModel): Observable<any> {
        return this.client.put(this.path, updateCarModel);
    }
}
