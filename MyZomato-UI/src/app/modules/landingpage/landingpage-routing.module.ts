import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CheckoutComponent } from './checkout/checkout.component';
import { SearchbarComponent } from './searchbar/searchbar.component';
import { MsalGuard } from '@azure/msal-angular';


const routes: Routes = [
  {path:'', component:SearchbarComponent, pathMatch:"full", canActivate:[MsalGuard]},
  {path:'checkout', component:CheckoutComponent, canActivate:[MsalGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LandingPageRoutingModule { }
