import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductslistComponent } from './productslist/productslist.component';
import { MsalGuard } from '@azure/msal-angular';

const routes:Routes = [
  {path:'products-for-restaurant/:restaurantId', component:ProductslistComponent, canActivate:[MsalGuard]}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class ProductsAppRoutingModule { }
