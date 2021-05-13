import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyordersComponent } from './myorders/myorders.component';
import {MatTableModule} from '@angular/material/table';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [MyordersComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatListModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class OrdersModule { }
