import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-quantity',
  templateUrl: './quantity.component.html',
  styleUrls: ['./quantity.component.css']
})
export class QuantityComponent implements OnInit {

  public productQuantity:number;

  constructor() { 
    this.productQuantity = 0;
    this.quantityChanged = new EventEmitter<number>();
  }

  ngOnInit(): void {
  }

  @Output()
  quantityChanged:EventEmitter<number>;

  decrement():void{
    if(this.productQuantity > 0 && this.productQuantity <= 10)
    {
      this.productQuantity -= 1;
      this.quantityChanged.emit(this.productQuantity);
    }    
  }

  increment():void{
    if(this.productQuantity < 10 && this.productQuantity >= 0)
    {
      this.productQuantity += 1;
      this.quantityChanged.emit(this.productQuantity);  
    } 
  }

}
