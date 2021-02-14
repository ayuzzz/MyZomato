import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyordersComponent } from './myorders/myorders.component';
import {MatTableModule} from '@angular/material/table';



@NgModule({
  declarations: [MyordersComponent],
  imports: [
    CommonModule,
    MatTableModule
  ]
})
export class OrdersModule { }
