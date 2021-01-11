import { Component, Input, OnInit } from '@angular/core';
import {IProduct} from '../../../core/models/IProduct';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input()
  public _product:IProduct;

  constructor() { 
    this._product = {} as IProduct;
  }

  ngOnInit(): void {
  }

}
