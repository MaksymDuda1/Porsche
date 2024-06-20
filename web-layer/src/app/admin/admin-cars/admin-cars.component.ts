import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../services/carService';
import { CarModel } from '../../../models/CarModel';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { PorscheCenterModel } from '../../../models/CenterModel';
import { PorscheCenterService } from '../../../services/PorscheCenterService';
import { BodyType, bodyTypeToString } from '../../../enums/BodyType';
import { colorToString } from '../../../enums/Color';

@Component({
  selector: 'app-admin-cars',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './admin-cars.component.html',
  styleUrl: './admin-cars.component.scss'
})
export class AdminCarsComponent implements OnInit {
  constructor(private carService: CarService,
    private porscheCenterService: PorscheCenterService
  ) { }

  cars: CarModel[] = [];
  errorMessage = '';
  porscheCenter: PorscheCenterModel = new PorscheCenterModel();
  porscheCenters: PorscheCenterModel[] = [];
  

  delete(id: string) {
    this.carService.deleteCar(id).subscribe(() => {
      this.carService.getAllCars().subscribe(data => {
        this.cars = data; 
        this.errorMessage = "Deleted"
      },
        errorResponse => this.errorMessage = errorResponse)
    },
      errorResponse => this.errorMessage = errorResponse)
  }

  getBodyType(value: number): string{
    return bodyTypeToString(value);
  }

  getColor(value: number): string{
    return colorToString(value);
  }

  getPorscheCenter(id: string): string {
    const porscheCenter = this.porscheCenters.find(center => center.id === id);
    return porscheCenter ? porscheCenter.name : 'Car without Porsche center';
  }

  ngOnInit(): void {
    this.carService.getAllCars().subscribe(
      data => {
        this.cars = data;
      },
      errorResponse => {
        this.errorMessage = errorResponse;
      }
    );
  
    this.porscheCenterService.getAll().subscribe(
      data => {
        this.porscheCenters = data;
      },
      errorResponse => {
        this.errorMessage = errorResponse;
      }
    );
  }
}
