import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductslistComponent } from './productslist/productslist.component';
import { ProductComponent } from './product/product.component';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [ProductslistComponent, ProductComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule
  ]
})
export class ProductsModule { }
