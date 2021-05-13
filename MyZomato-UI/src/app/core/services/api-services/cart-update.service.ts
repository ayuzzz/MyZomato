import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { IProduct } from '../../models/product';

@Injectable({
  providedIn: 'root'
})
export class CartUpdateService {


  cartQuantity;

  constructor() { 
    var productsInCart = JSON.parse(localStorage.getItem("productsInCart") as string) as IProduct[];
    this.cartQuantity = new BehaviorSubject<number>(productsInCart != null ? productsInCart.length :0);
  }
}
