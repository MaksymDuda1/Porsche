import { Component, ElementRef, ViewChild } from '@angular/core';
import { SearchService } from '../../../services/seearcService';
import { SeaarchByConditionalsModel } from '../../../models/searchByConditionalsModel';
import { CarModel } from '../../../models/CarModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss'
})
export class ToolbarComponent {
  constructor(private searchService: SearchService) {

  }

  cars: CarModel[] = [];
  errorMessage: string = '';
  searchByConditionalsModel = new SeaarchByConditionalsModel();
  years: number[] = [];

  @ViewChild('parentMenuItem', { static: false }) parentMenuItem!: ElementRef;

  toggleSubMenu(submenuId: string) {
    const subMenu = this.parentMenuItem.nativeElement.querySelector(`#${submenuId}`);
    if (subMenu) {
      const isExpanded = subMenu.classList.contains('expanded');
      const subMenuItems = this.parentMenuItem.nativeElement.querySelectorAll('.sub-menu');

      subMenuItems.forEach((item: Element) => item.classList.remove('expanded'));

      if (!isExpanded) {
        subMenu.classList.add('expanded');
      }
    }
  }

  seedYears() {
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 50; 

    for (let year = currentYear; year >= startYear; year--) {
      this.years.push(year);
    }
  }

  selectModel(model: string) {
    this.searchByConditionalsModel.model = model;
  }

  onMinPriceChange() {
    if (this.searchByConditionalsModel.minPrice === null || this.searchByConditionalsModel.minPrice === undefined) {
      this.searchByConditionalsModel.minPrice = 0;
    }
  }

  onMaxPriceChange() {
    if (this.searchByConditionalsModel.maxPrice === null || this.searchByConditionalsModel.maxPrice === undefined) {
      this.searchByConditionalsModel.maxPrice = 0;
    }
  }


  onSearch() {
    this.searchService.searchByConditionals(this.searchByConditionalsModel).subscribe(data => {
      this.cars = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }
}

