import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {IProduct} from '../../../core/models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input()
  public _product:IProduct;

  @Output()
  updateCartEvent:EventEmitter<IProduct>; 

  constructor() { 
    this._product = {} as IProduct;
    this.updateCartEvent = new EventEmitter<IProduct>();
  }

  ngOnInit(): void {
  }

  productQuantityChanged(quantity:number):void{
    this.cartUpdated(quantity);
  }

  cartUpdated(quantity:number){
    this._product.quantity = quantity;
    this.updateCartEvent.emit(this._product);
  }

}
