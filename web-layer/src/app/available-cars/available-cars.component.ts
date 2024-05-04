import { Component, OnInit } from '@angular/core';
import { CarCardComponent } from './car-card/car-card.component';
import { CommonModule } from '@angular/common';
import { CarService } from '../../services/carService';
import { CarModel } from '../../models/CarModel';
import { ToolbarComponent } from './toolbar/toolbar.component';

@Component({
  selector: 'app-available-cars',
  standalone: true,
  imports: [CarCardComponent, ToolbarComponent, CommonModule],
  templateUrl: './available-cars.component.html',
  styleUrl: './available-cars.component.scss'
})
export class AvailableCarsComponent implements OnInit {
  constructor(private carService: CarService) {

  }

  cars: CarModel[] = [];
  errorMessage: string = "";

  ngOnInit(): void {
    this.carService.getAllCars().subscribe((data) => {
      this.cars = data;
    })
  }
}
