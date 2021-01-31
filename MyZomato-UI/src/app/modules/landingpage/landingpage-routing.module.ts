import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CheckoutComponent } from './checkout/checkout.component';
import { SearchbarComponent } from './searchbar/searchbar.component';


const routes: Routes = [
  {path:'', component:SearchbarComponent, pathMatch:"full"},
  {path:'checkout', component:CheckoutComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LandingPageRoutingModule { }
