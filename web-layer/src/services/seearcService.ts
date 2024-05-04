import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SeaarchByConditionalsModel } from "../models/searchByConditionalsModel";
import { Observable } from "rxjs";
import { CarModel } from "../models/CarModel";
import { parentPort } from "worker_threads";

@Injectable({providedIn: "root"})
export class SearchService{
    constructor(private client: HttpClient){

    }


    private path: string = "api/search/";


    searchByConditionals(searchByConditionalsModel: SeaarchByConditionalsModel): Observable<CarModel[]>
    {
        let params = new HttpParams();

        if(searchByConditionalsModel.bodyType != null)
            params = params.append("bodyType", searchByConditionalsModel.bodyType);
        if(searchByConditionalsModel.engine != null)
            params = params.append("engine", searchByConditionalsModel.engine);
        if(searchByConditionalsModel.minPrice != null)
            params = params.append("minPrice", searchByConditionalsModel.minPrice);
        if(searchByConditionalsModel.maxPrice != null)
            params = params.append("maxPrice", searchByConditionalsModel.maxPrice);
        if(searchByConditionalsModel.minYearOfRelease != null)
            params = params.append("minYearOfRelease", searchByConditionalsModel.minYearOfRelease);
        if(searchByConditionalsModel.minYearOfRelease != null)
            params = params.append("maxYearOfRealease", searchByConditionalsModel.maxYearOfRelease);
        if(searchByConditionalsModel.model != null)
            params = params.append("model", searchByConditionalsModel.model);
        if(searchByConditionalsModel.porscheCenter != null)
            params = params.append("porscheCenter", searchByConditionalsModel.porscheCenter);

        return this.client.get<any>(this.path + 'conditionals', {params} )
    }
}