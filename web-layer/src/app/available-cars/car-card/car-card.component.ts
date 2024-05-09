import { Component, Input, OnInit, input } from '@angular/core';
import { CarModel } from '../../../models/CarModel';
import { CommonEngine } from '@angular/ssr';
import { CommonModule } from '@angular/common';
import { BrowserModule, SafeUrl } from '@angular/platform-browser';
import { Router } from 'express';
import { RouterModule } from '@angular/router';
import { PorscheCenterCreateModel } from '../../../models/porscheCenterCreateModel';
import { PorscheCenterModel } from '../../../models/CenterModel';
import { PorscheCenterService } from '../../../services/PorscheCenterService';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';

@Component({
  selector: 'app-car-card',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './car-card.component.html',
  styleUrl: './car-card.component.scss'
})

export class CarCardComponent implements OnInit {
  constructor(private sanitizer: ImgSanitizerService, 
    private porscheCenterService: PorscheCenterService
  ){}
  @Input() car!: CarModel;

  porshceCenter = new PorscheCenterModel();
  errorMessage: string = '';

  sanitizeImg(img: string): SafeUrl {
    return this.sanitizer.sanitizeImg(img);
  }

  ngOnInit(): void {
    this.porscheCenterService.getById(this.car.porscheCenterId).subscribe(data => {
      this.porshceCenter = data;
    },
      errorResponse => this.errorMessage = errorResponse.error)
  }
}
