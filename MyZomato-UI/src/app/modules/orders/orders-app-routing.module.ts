import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MyordersComponent } from './myorders/myorders.component';

const routes:Routes = [
  {path:'my-orders', component:MyordersComponent}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports:[RouterModule]
})
export class OrdersAppRoutingModule { }
