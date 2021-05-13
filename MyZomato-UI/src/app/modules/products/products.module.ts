import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductslistComponent } from './productslist/productslist.component';
import { ProductComponent } from './product/product.component';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { QuantityComponent } from './quantity/quantity.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { CategorySeperatorComponent } from './category-seperator/category-seperator.component';



@NgModule({
  declarations: [ProductslistComponent, ProductComponent, QuantityComponent, CategorySeperatorComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    MatButtonModule,
    MatInputModule
  ]
})
export class ProductsModule { }
