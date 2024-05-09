import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PorscheCenterService } from '../../../services/PorscheCenterService';
import { PorscheCenterModel } from '../../../models/CenterModel';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-admin-centers',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './admin-centers.component.html',
  styleUrl: './admin-centers.component.scss'
})
export class AdminCentersComponent implements OnInit {
  constructor(private centerService: PorscheCenterService,
    private sanitizer: ImgSanitizerService
  ) { }

  centers: PorscheCenterModel[] = [];
  errorMessage = '';

  sanitizeImg(img: string): SafeUrl {
    console.log(img);
    return this.sanitizer.sanitizeImg(img);
  }

  delete(id: string) {
    this.centerService.delete(id).subscribe(() => {
      this.centerService.getAll().subscribe(data => {
        this.centers = data;
      },
        errorResponse => this.errorMessage = errorResponse.error)
    },
      errorResponse => this.errorMessage = errorResponse.error)
  }

  ngOnInit(): void {
    this.centerService.getAll().subscribe(data => {
      this.centers = data;
  
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }
}
