import { Component } from '@angular/core';
import { CarService } from '../../../../services/carService';
import { CreateCarModel } from '../../../../models/createCarModel';
import { PorscheCenterService } from '../../../../services/PorscheCenterService';
import { PorscheCenterCreateModel } from '../../../../models/porscheCenterCreateModel';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-create-center',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './create-center.component.html',
  styleUrl: './create-center.component.scss'
})
export class CreateCenterComponent {
  constructor(private porscheCenterService: PorscheCenterService) { }


  porscheCenterCreateModel = new PorscheCenterCreateModel();
  
  message: string = '';

  onFileChange(event: any) {
    this.porscheCenterCreateModel.photo = event.target.files[0];
  }

  onCreate() {
    let formData = new FormData();
    formData.append("Name", this.porscheCenterCreateModel.name);
    formData.append("Address", this.porscheCenterCreateModel.address);
    if(this.porscheCenterCreateModel.photo)
      formData.append("PhotoPath", this.porscheCenterCreateModel.photo);

    this.porscheCenterService.create(formData).subscribe(() => {
      this.message = "Created";
    },
      errorResponse => this.message = errorResponse)
  }
}
