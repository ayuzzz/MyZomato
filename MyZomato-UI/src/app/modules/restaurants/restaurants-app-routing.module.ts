import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';

const routes: Routes = [
  {path:'restaurants-in-city/:cityId', component:RestaurantsListComponent}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class RestaurantsAppRoutingModule { }
