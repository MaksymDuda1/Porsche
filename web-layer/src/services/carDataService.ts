import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CarModel } from '../models/CarModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private searchDataSubject = new BehaviorSubject<CarModel[]>([]);
  searchData$ = this.searchDataSubject.asObservable();

  updateSearchData(data: CarModel[]) {
    this.searchDataSubject.next(data);
  }
}
