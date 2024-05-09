import { Routes } from "@angular/router";
import { AdminUsersComponent } from "./admin-users/admin-users.component";
import { CreateCarComponent } from "./admin-cars/create-car/create-car.component";
import { AdminCarsComponent } from "./admin-cars/admin-cars.component";
import { UpdateCarComponent } from "./admin-cars/update-car/update-car.component";
import { AdminCentersComponent } from "./admin-centers/admin-centers.component";
import { CreateCenterComponent } from "./admin-centers/create-center/create-center.component";
import { UpdateCenterComponent } from "./admin-centers/update-center/update-center.component";

export const adminRoutes: Routes = [
    {path:'admin-users', component: AdminUsersComponent},
    {path: 'admin-cars', component: AdminCarsComponent},
    {path: 'admin-cars/create-car', component: CreateCarComponent},
    {path: 'admin-cars/update-car/:id', component: UpdateCarComponent},
    {path: 'admin-centers', component: AdminCentersComponent},
    {path: 'admin-centers/create-center', component: CreateCenterComponent},
    {path: 'admin-centers/update-center/:id', component: UpdateCenterComponent}
]

export class AdminRoutingModule{}