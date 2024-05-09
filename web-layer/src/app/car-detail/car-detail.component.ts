import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarService } from '../../services/carService';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from '../../services/userService';
import { CarModel } from '../../models/CarModel';
import { CarImagesComponent } from './car-images/car-images.component';
import { CarInfoComponent } from './car-info/car-info.component';
import { PorscheCenterModel } from '../../models/CenterModel';
import { PorscheCenterService } from '../../services/PorscheCenterService';
import { OrderComponent } from './order/order.component';

@Component({
  selector: 'app-car-detail',
  standalone: true,
  imports: [CarImagesComponent, CarInfoComponent, OrderComponent],
  templateUrl: './car-detail.component.html',
  styleUrl: './car-detail.component.scss'
})
export class CarDetailComponent {
  constructor(private router: ActivatedRoute,
    private carService: CarService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private userService: UserService,
    private porscheCenterService: PorscheCenterService
  ) {
    this.router.paramMap.subscribe((params) => {
      let id = params.get('id');
      if (id != null)
        this.carService.getById(id).subscribe(data => {
          this.car = data
          this.porscheCenterService.getById(this.car.porscheCenterId).subscribe(data =>{
            this.porscheCenter = data
          })
        });
    })
  }

  car: CarModel = new CarModel();
  porscheCenter =  new PorscheCenterModel();
}



