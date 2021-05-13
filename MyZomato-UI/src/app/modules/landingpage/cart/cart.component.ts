import { Component, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { EventEmitter } from '@angular/core';
import { IProduct } from 'src/app/core/models/product';
import { CartUpdateService } from 'src/app/core/services/api-services/cart-update.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  @Output()
  toggleThemeEvent:EventEmitter<boolean>;

  isDark:boolean;
  productsInCartCount:number;

  constructor(private _router:Router, private _cartUpdateService:CartUpdateService) { 
    let products:IProduct[] = JSON.parse(localStorage.getItem('productsInCart') as string) as IProduct[];
    this.toggleThemeEvent = new EventEmitter<boolean>();
    this.isDark = JSON.parse(localStorage.getItem('isDark')as string) as boolean;
    if(this.isDark === null)
    {
      localStorage.setItem('isDark', JSON.stringify(false));
    }
    this.productsInCartCount = products != null ? products.length :0;
    this._cartUpdateService.cartQuantity.subscribe((quantity) => this.productsInCartCount = quantity);
  }

  ngOnInit(): void {
  }

  checkout():void{
    this._router.navigate(['/landingpage/checkout']);
  }

  toggleTheme()
  {
    var darkTheme = JSON.parse(localStorage.getItem('isDark')as string) as boolean;
    if(darkTheme != null)
    {
      this.toggleThemeEvent.emit(darkTheme);
    }
  }

}
