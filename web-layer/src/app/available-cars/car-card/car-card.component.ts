import { Component, Input, input } from '@angular/core';
import { CarModel } from '../../../models/CarModel';
import { CommonEngine } from '@angular/ssr';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-car-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './car-card.component.html',
  styleUrl: './car-card.component.scss'
})

export class CarCardComponent{
  @Input() car!: CarModel;
}
