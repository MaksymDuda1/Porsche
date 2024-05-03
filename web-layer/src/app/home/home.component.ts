import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { SliderComponent } from './slider/slider.component';
import { ModelsRowComponent } from './models-row/models-row.component';
import { MultiSliderComponent } from './multi-slider/multi-slider.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, SliderComponent, ModelsRowComponent, MultiSliderComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
