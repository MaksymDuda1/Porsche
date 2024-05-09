import { Component, Input, OnInit } from '@angular/core';
import { CarModel } from '../../../models/CarModel';
import { PorscheCenterService } from '../../../services/PorscheCenterService';
import { PorscheCenterModel } from '../../../models/CenterModel';
import { BodyType, bodyTypeToString } from '../../../enums/BodyType';
import { Color, colorToString } from '../../../enums/Color';

@Component({
  selector: 'app-car-info',
  standalone: true,
  imports: [],
  templateUrl: './car-info.component.html',
  styleUrls: ['./car-info.component.scss']
})
export class CarInfoComponent {
  constructor(private porscheCenterService: PorscheCenterService){}

  @Input() car!: CarModel;
  @Input() porscheCenter! : PorscheCenterModel;
  errorMessage = '';

  getBodyType(type: BodyType){
    return bodyTypeToString(type)
  }

  getColorType(color: Color){
    return colorToString(color);
  }


}