import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';

import { RestaurantsAppRoutingModule } from './restaurants-app-routing.module';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { RestaurantComponent } from './restaurant/restaurant.component';



@NgModule({
  declarations: [RestaurantsListComponent, RestaurantComponent],
  imports: [
    CommonModule,
    RestaurantsAppRoutingModule,
    MatCardModule,
    MatIconModule,
    MatDividerModule
  ]
})
export class RestaurantsModule { }
