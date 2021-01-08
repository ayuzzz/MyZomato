import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantsAppRoutingModule } from './restaurants-app-routing.module';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { RestaurantComponent } from './restaurant/restaurant.component';



@NgModule({
  declarations: [RestaurantsListComponent, RestaurantComponent],
  imports: [
    CommonModule,
    RestaurantsAppRoutingModule
  ]
})
export class RestaurantsModule { }
