import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CarService } from '../../services/carService';
import { CarModel } from '../../models/CarModel';
import { UserService } from '../../services/userService';
import { Locals } from 'express';
import { LocalService } from '../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-favorite-cars',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './favorite-cars.component.html',
  styleUrl: './favorite-cars.component.scss'
})
export class FavoriteCarsComponent implements OnInit{

  constructor(private userService: UserService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService
  ){}

  cars: CarModel[] = [];
  errorMessage = '';
  userId = '';

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName)

    if(token){
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.userId = decodedData.jti;
      this.userService.getById(this.userId).subscribe(data => {
        this.cars = data;
      },errorResponse => this.errorMessage = errorResponse.error)
    }
    else{
      this.errorMessage = "You need to login";
    }

  }
}
