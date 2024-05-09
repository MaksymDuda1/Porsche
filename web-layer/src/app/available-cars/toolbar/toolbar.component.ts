import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { SearchService } from '../../../services/seearcService';
import { CarModel } from '../../../models/CarModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SearchByConditionalsModel } from '../../../models/searchByConditionalsModel';
import { DataService } from '../../../services/carDataService';
import { bodyTypeToString, stringToBodyType } from '../../../enums/BodyType';
import { colorToString, stringToColor } from '../../../enums/Color';
import { PorscheCenterCreateModel } from '../../../models/porscheCenterCreateModel';
import { PorscheCenterService } from '../../../services/PorscheCenterService';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss'
})
export class ToolbarComponent implements OnInit{
  constructor(private searchService: SearchService,
    private carDataService: DataService,
    private porshceCenterService: PorscheCenterService
  ) {

  }
  
  cars: CarModel[] = [];
  errorMessage: string = '';
  searchByConditionalsModel = new SearchByConditionalsModel();
  years: number[] = [];
  subMenuStates: { [key: string]: boolean } = {};
  porshceCenters: PorscheCenterCreateModel[] = [];

  toggleSubMenu(subMenuId: string) {
    this.subMenuStates[subMenuId] = !this.subMenuStates[subMenuId];
  }

  selectBodyTypes() {
    const checkboxes = Array.from(document.querySelectorAll('input[name="body-type"]:checked')) as HTMLInputElement[];
    checkboxes.forEach(checkbox => {
      this.searchByConditionalsModel.bodyType.push(stringToBodyType(checkbox.value));
    });
  }  

  selectColors() {
    const checkboxes = Array.from(document.querySelectorAll('input[name="color"]:checked')) as HTMLInputElement[];
    checkboxes.forEach(checkbox => {
      this.searchByConditionalsModel.color.push(stringToColor(checkbox.value));
    });
  }  

  selectEngines() {
    const checkboxes = Array.from(document.querySelectorAll('input[name="engine"]:checked')) as HTMLInputElement[];
    checkboxes.forEach(checkbox => {
      console.log(checkbox.value)
      this.searchByConditionalsModel.engine.push(checkbox.value);
    });
  }  

  selectCenters() {
    const checkboxes = Array.from(document.querySelectorAll('input[name="porsche-center"]:checked')) as HTMLInputElement[];
    checkboxes.forEach(checkbox => {
      console.log(checkbox.value)
      this.searchByConditionalsModel.porscheCenter.push(checkbox.value);
    });
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
      this.searchByConditionalsModel.minPrice = null;
    }
  }

  onMaxPriceChange() {
    if (this.searchByConditionalsModel.maxPrice === null || this.searchByConditionalsModel.maxPrice === undefined) {
      this.searchByConditionalsModel.maxPrice = null;
    }
  }


  onSearch() {
    this.selectBodyTypes();
    this.selectColors();
    this.selectEngines();
    this.selectCenters();
    this.searchByConditionalsModel.bodyType.forEach(type => {
      console.log(type);
    });
    this.searchService.searchByConditionals(this.searchByConditionalsModel).subscribe(
      data => {
        this.carDataService.updateSearchData(data);
        this.searchByConditionalsModel = new SearchByConditionalsModel();
      },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      }
    );
  }
  

  ngOnInit(): void {
    this.porshceCenterService.getAll().subscribe(data => {
      this.porshceCenters = data;
    }
  ,errorResponse => this.errorMessage = errorResponse.error)
    this.seedYears();
  }
  
}

