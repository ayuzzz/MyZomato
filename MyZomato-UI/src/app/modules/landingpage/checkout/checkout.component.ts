import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/core/models/product';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  checkoutContents:IProduct[]
  productsInCartCount:number;
  displayedColumns: string[];

  constructor() { 
    this.checkoutContents = JSON.parse(localStorage.getItem('productsInCart') as string) as IProduct[];

    this.productsInCartCount = this.checkoutContents != null ? this.checkoutContents.length :0;

    this.displayedColumns = ['Item', 'Quantity', 'Cost'];
  }

  
  ngOnInit(): void {
  }

  getTotalCost():number{
    return this.checkoutContents.map(item => item.price * item.quantity).reduce((prev, curr) => prev + curr, 0);
  }

}
