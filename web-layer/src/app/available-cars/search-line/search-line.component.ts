import { Component } from '@angular/core';
import { SearchService } from '../../../services/seearcService';
import { CarModel } from '../../../models/CarModel';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DataService } from '../../../services/carDataService';
import { CarService } from '../../../services/carService';
import { UpdateCarComponent } from '../../admin/admin-cars/update-car/update-car.component';

@Component({
  selector: 'app-search-line',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-line.component.html',
  styleUrl: './search-line.component.scss'
})
export class SearchLineComponent {
  constructor(private searchService: SearchService,
    private carService: CarService,
    private dataService: DataService
  ) { }

  searchText = '';
  cars: CarModel[] = [];
  errorMessage = '';

  onSearch() {
    if (this.searchText.trim() === '') {
      this.carService.getAllCars().subscribe(data =>
        this.dataService.updateSearchData(data))
    }
    this.searchService.searchByModel(this.searchText).subscribe(data =>
      this.dataService.updateSearchData(data),
      errorResponse => this.errorMessage = errorResponse
    )
  }
}
