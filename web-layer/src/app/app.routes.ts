import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AvailableCarsComponent } from './available-cars/available-cars.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { AdminComponent } from './admin/admin.component';
import { FavoriteCarsComponent } from './favorite-cars/favorite-cars.component';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {path:"login", component: LoginComponent},
    {path:"registration", component: RegistrationComponent},
    {path:"available-cars", component: AvailableCarsComponent},
    {path:"car-detail/:id", component: CarDetailComponent},
    {path: "admin", component: AdminComponent},
    {path:"favorite-cars", component: FavoriteCarsComponent},
];
