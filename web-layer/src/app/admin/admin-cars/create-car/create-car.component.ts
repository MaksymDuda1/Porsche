import { Component, OnInit } from '@angular/core';
import { CarService } from '../../../../services/carService';
import { CreateCarModel } from '../../../../models/createCarModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BodyType } from '../../../../enums/BodyType';
import { Color } from '../../../../enums/Color';
import { RouterModule } from '@angular/router';
import { PorscheCenterCreateModel } from '../../../../models/porscheCenterCreateModel';
import { PorscheCenterService } from '../../../../services/PorscheCenterService';
import { PorscheCenterModel } from '../../../../models/CenterModel';
import { ImgSanitizerService } from '../../../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-create-car',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './create-car.component.html',
  styleUrls: ['./create-car.component.scss']
})
export class CreateCarComponent implements OnInit {
  constructor(
    private carService: CarService,
    private porscheCenterService: PorscheCenterService,
    private sanitizer: ImgSanitizerService
  ) { }

  porscheCenterModels: PorscheCenterModel[] = [];
  bodyTypes = Object.values(BodyType);
  colors = Object.values(Color);
  colorsValues =  this.colors.filter(item => typeof item === 'string');
  bodyTypesValues =  this.bodyTypes.filter(item => typeof item === 'string');
  years: number[] = [];
  createCarModel = new CreateCarModel();
  message = '';
  photos: File[] = [];

  seedYears() {
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 50; 

    for (let year = currentYear; year >= startYear; year--) {
      this.years.push(year);
    }
  }

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  onCreate() {
    const formData = new FormData();
    formData.append("IdentityCode", this.createCarModel.identityCode);
    formData.append("Model", this.createCarModel.model);
    formData.append("BodyType", this.createCarModel.bodyType.toString());
    formData.append("Color", this.createCarModel.color.toString());
    formData.append("Engine", this.createCarModel.engine);
    formData.append("FuelConsumption", this.createCarModel.fuelConsumption.toString());
    formData.append("YearOfEdition", this.createCarModel.yearOfEdition.toString());
    formData.append("PorscheCenterId", this.createCarModel.porscheCenterId.toString());
    formData.append("Price", this.createCarModel.price.toString());

    for (const photo of this.photos) {
      formData.append("Photos", photo);
    }

    this.carService.createCar(formData).subscribe(
      () => {
        this.message = "Car created successfully";
      },
      errorResponse => this.message = errorResponse
    );
  }

  ngOnInit(): void {
    this.porscheCenterService.getAll().subscribe(
      data => {
        this.porscheCenterModels = data;
        this.seedYears();
      },
      errorResponse => this.message = errorResponse
    );
  }

  onFileChange(event: any) {
    this.photos = event.target.files;
  }
}