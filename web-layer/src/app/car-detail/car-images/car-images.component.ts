import { Component, Input, input } from '@angular/core';
import { CarModel } from '../../../models/CarModel';
import { CommonModule } from '@angular/common';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-car-images',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './car-images.component.html',
  styleUrl: './car-images.component.scss'
})
export class CarImagesComponent {
  constructor(private sanitizer: ImgSanitizerService){}
  @Input() car!: CarModel;

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }
}
