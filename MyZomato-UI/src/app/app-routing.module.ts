import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'landingpage', loadChildren: () => import ('./modules/landingpage/landingpage.module').then((module) => module.LandingpageModule)},
  {path:'restaurants', loadChildren:() => import('./modules/restaurants/restaurants.module').then((module) => module.RestaurantsModule)}
  // {path:'**', pathMatch : 'full', redirectTo:'landingpage'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
