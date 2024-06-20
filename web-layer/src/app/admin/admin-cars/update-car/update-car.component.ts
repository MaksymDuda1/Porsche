import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SafeUrl } from '@angular/platform-browser';
import { CarService } from '../../../../services/carService';
import { PorscheCenterService } from '../../../../services/PorscheCenterService';
import { ImgSanitizerService } from '../../../../services/imgSanitizerService';
import { BodyType, bodyTypeToString, stringToBodyType } from '../../../../enums/BodyType';
import { Color, colorToString } from '../../../../enums/Color';
import { PorscheCenterModel } from '../../../../models/CenterModel';
import { CreateCarModel } from '../../../../models/createCarModel';
import { UpdateCarModel } from '../../../../models/UpdateCarModel';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CarModel } from '../../../../models/CarModel';

@Component({
  selector: 'app-update-car',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './update-car.component.html',
  styleUrl: './update-car.component.scss'
})
export class UpdateCarComponent {
  constructor(
    private carService: CarService,
    private porscheCenterService: PorscheCenterService,
    private sanitizer: ImgSanitizerService,
    private route: ActivatedRoute
  ) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id != null) {
        this.getById(id);
      }
    })
  }

  porscheCenterModels: PorscheCenterModel[] = [];
  bodyTypes = Object.values(BodyType);
  colors = Object.values(Color);
  colorsValues = this.colors.filter(item => typeof item === 'number') as Color[];
  bodyTypesValues: BodyType[] = this.bodyTypes.filter(item => typeof item === 'number') as BodyType[];
  years: number[] = [];
  updateCarModel = new CarModel();
  message = '';
  photos: File[] = [];

  seedYears() {
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 50;

    for (let year = currentYear; year >= startYear; year--) {
      this.years.push(year);
    }
  }

  getBodyType(type: BodyType) {
    return bodyTypeToString(type);
  }

  getColor(type: Color) {
    return colorToString(type);
  }

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  getById(id: string) {
    this.carService.getById(id).subscribe(data => {
      this.updateCarModel = data;
    },
      errorResponse => this.message = errorResponse.error)
  }

  onCreate() {
    const formData = new FormData();
    formData.append("Model", this.updateCarModel.model);
    formData.append("BodyType", this.updateCarModel.bodyType.toString());
    formData.append("Color", this.updateCarModel.color.toString());
    formData.append("Engine", this.updateCarModel.engine);
    formData.append("FuelConsumption", this.updateCarModel.fuelConsumption.toString());
    formData.append("YearOfEdition", this.updateCarModel.yearOfEdition.toString());
    formData.append("PorscheCenterId", this.updateCarModel.porscheCenterId.toString());
    formData.append("Price", this.updateCarModel.price.toString());

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
