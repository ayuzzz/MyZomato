import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IProduct } from 'src/app/core/models/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  productsInCartCount:number;

  constructor(private _router:Router) { 
    let products:IProduct[] = JSON.parse(localStorage.getItem('productsInCart') as string) as IProduct[];

    this.productsInCartCount = products != null ? products.length :0;
  }

  ngOnInit(): void {
  }

  checkout():void{
    this._router.navigate(['/landingpage/checkout']);
  }
}
