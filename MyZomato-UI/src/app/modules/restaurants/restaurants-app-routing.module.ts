import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { MsalGuard } from '@azure/msal-angular';

const routes: Routes = [
  {path:'restaurants-in-city/:cityId', component:RestaurantsListComponent, canActivate:[MsalGuard]}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class RestaurantsAppRoutingModule { }
