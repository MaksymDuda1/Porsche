import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserService } from '../../../services/userService';
import { UserModel } from '../../../models/userModel';
import { AdminService } from '../../../services/adminService';
import { ChangeRoleModel } from '../../../models/changeRoleModel';
import { LocalService } from '../../../services/localService';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-admin-users',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.scss'
})
export class AdminUsersComponent implements OnInit {
  constructor(private userService: UserService,
    private adminService: AdminService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService
  ) {

  }

  users: UserModel[] = [];
  errorMessage: string = '';
  currentUserId: string = '';

  changeRole(id: string){
    let changeRole = new ChangeRoleModel();
    changeRole.id = id;
    
    this.adminService.changeRole(changeRole).subscribe(() => {
      this.userService.getAll().subscribe(data => {
        this.users = data;
      },
    errorResponse => this.errorMessage = errorResponse.error)
    },
  errorResponse => this.errorMessage = errorResponse.error)
  }

  delete(id: string) {
    this.userService.delete(id).subscribe(() => {
      this.userService.getAll().subscribe(data => {
        this.users = data;
      },
        errroResponse => this.errorMessage = errroResponse.error)
    },
      errorResponse => this.errorMessage = errorResponse.error)
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      let decodedData = this.jwtHelperService.decodeToken(token);
      this.currentUserId = decodedData.jti;
    }
    this.userService.getAll().subscribe(data => {
      this.users = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }

}
