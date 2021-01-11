import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductslistComponent } from './productslist/productslist.component';

const routes:Routes = [
  {path:'products-for-restaurant/:restaurantId', component:ProductslistComponent}
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
