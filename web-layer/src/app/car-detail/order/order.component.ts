import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PorscheCenterModel } from '../../../models/CenterModel';
import { CarModel } from '../../../models/CarModel';
import { LocalService } from '../../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from '../../../services/userService';
import { AddToFavoriteModel } from '../../../models/addToFavoriteModel';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { OrderModel } from '../../../models/orderModel';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss'
})
export class OrderComponent implements OnInit {
  modalRef: NgbModalRef | undefined;
  constructor(private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private userService: UserService,
    private modalService: NgbModal
  ) { }
  @ViewChild('modal') modal: any;
  @Input() porscheCenter!: PorscheCenterModel;
  @Input() car!: CarModel;
  userId: string = '';
  isInFavorite: boolean = false;

  onAdd() {
    let addToFavoriteModel: AddToFavoriteModel = new AddToFavoriteModel();
    addToFavoriteModel.userId = this.userId;
    addToFavoriteModel.carId = this.car.id;

    this.userService.addToFavorite(addToFavoriteModel).subscribe(() => {
      this.isInFavorite ? this.isInFavorite = false : this.isInFavorite = true;
    })
  }

  onOrder() {
    let orderModel = new OrderModel();
    orderModel.userId = this.userId;
    orderModel.carId = this.car.id;
    this.userService.order(orderModel).subscribe(()=>{
      this.modalRef = this.modalService.open(this.modal);
    })
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.userId = decodedData.jti;

      this.userService.isInFavorite(this.userId, this.car.id).subscribe(data => {
        this.isInFavorite = data;
      })
    }
  }
}
