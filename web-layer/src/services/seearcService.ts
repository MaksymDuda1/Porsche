import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CarModel } from "../models/CarModel";
import { SearchByConditionalsModel } from "../models/searchByConditionalsModel";

@Injectable({ providedIn: "root" })
export class SearchService {
    constructor(private client: HttpClient) {

    }


    private path: string = "api/search/";


    searchByConditionals(searchByConditionalsModel: SearchByConditionalsModel): Observable<CarModel[]> {
        let params = new HttpParams();

        if (searchByConditionalsModel.bodyType.length != 0) {
            searchByConditionalsModel.bodyType.forEach(value => {
                params = params.append("BodyType", value);
            });
        }

        if (searchByConditionalsModel.color.length != 0) {
            searchByConditionalsModel.color.forEach(value => {
                params = params.append("color", value);
            });
        }


        if (searchByConditionalsModel.engine.length != 0) {
            searchByConditionalsModel.engine.forEach(value => {
                params = params.append("engine", value);
            });
        }

        if (searchByConditionalsModel.porscheCenter != null) {
            searchByConditionalsModel.porscheCenter.forEach(value => {
                params = params.append("porscheCenter", value);
            });
        }
        
        if (searchByConditionalsModel.minPrice != null)
            params = params.append("minPrice", searchByConditionalsModel.minPrice);
        if (searchByConditionalsModel.maxPrice != null)
            params = params.append("maxPrice", searchByConditionalsModel.maxPrice);
        if (searchByConditionalsModel.minYearOfRelease != null)
            params = params.append("minYearOfRelease", searchByConditionalsModel.minYearOfRelease);
        if (searchByConditionalsModel.maxYearOfRelease != null)
            params = params.append("MaxYearOfRelease", searchByConditionalsModel.maxYearOfRelease);
        if (searchByConditionalsModel.model != null)
            params = params.append("model", searchByConditionalsModel.model);

        return this.client.get<any>(this.path + 'conditionals', { params })
    }

    searchByModel(searchParams: string): Observable<any> {
        let params = new HttpParams();
        if (searchParams != null)
            params = params.append("searchQuery", searchParams);
        return this.client.get<any>(this.path + 'model', { params })
    }

    searchByIdenitity(searchParams: string): Observable<any> {
        let params = new HttpParams();
        if (searchParams != null)
            params = params.append("searchQuery", searchParams);
        return this.client.get<any>(this.path + 'identity', { params })
    }
}