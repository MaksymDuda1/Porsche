import { Component, OnDestroy, OnInit } from '@angular/core';
import { CarCardComponent } from './car-card/car-card.component';
import { CommonModule } from '@angular/common';
import { CarService } from '../../services/carService';
import { CarModel } from '../../models/CarModel';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { Observable, Subscription } from 'rxjs';
import { DataService } from '../../services/carDataService';
import { SearchLineComponent } from './search-line/search-line.component';

@Component({
  selector: 'app-available-cars',
  standalone: true,
  imports: [CarCardComponent, ToolbarComponent, CommonModule, SearchLineComponent],
  templateUrl: './available-cars.component.html',
  styleUrl: './available-cars.component.scss'
})
export class AvailableCarsComponent implements OnInit, OnDestroy {
  cars: CarModel[] = [];
  errorMessage = '';
  private carsSubscription: Subscription;

  constructor(private carDataService: DataService,
    private carService: CarService
  ) {
    this.carsSubscription = this.carDataService.searchData$.subscribe(
      data => {
        this.cars = data;
      },
      error => {
        this.errorMessage = error;
      }
    );
  }

  ngOnInit(): void {
    this.carService.getAllCars().subscribe(data => {
      this.cars = data;
    })
  }

  ngOnDestroy(): void {
    this.carsSubscription.unsubscribe();
  }
}