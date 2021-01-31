import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IOrder, IOrderProduct } from 'src/app/core/models/order';
import {IProduct} from 'src/app/core/models/product';
import { OrderApiService } from 'src/app/core/services/api-services/order-api.service';


@Component({
  selector: 'app-success-dialog',
  templateUrl: './success-dialog.component.html',
  styleUrls: ['./success-dialog.component.css']
})
export class SuccessDialogComponent implements OnInit {

  constructor(public dialog: MatDialog, private router:Router, private _orderApiService:OrderApiService) { }

  ngOnInit(): void {
  }

  openSuccessDialog(){

    
    this._orderApiService.createOrder(this.createOrderObject()).subscribe(data => {});
    localStorage.removeItem('restaurantId');
    localStorage.removeItem('productsInCart');

    const successDialogReference = this.dialog.open(SuccessDialogContent);
    successDialogReference.afterClosed().subscribe(result => {
      this.router.navigate(['landingpage']);
    });
  }

  createOrderObject():IOrder{
    let order:IOrder = new Object() as IOrder;
    order.restaurantId = JSON.parse(localStorage.getItem('restaurantId') as string) as number;

    order.orderProducts = [] as IOrderProduct[];

    let orderProducts = JSON.parse(localStorage.getItem('productsInCart') as string) as IProduct[];
    orderProducts.forEach(product => {
      order.orderProducts.push({productId:product.id, quantity:product.quantity, price:product.price*product.quantity});
    });

    return order;
  }
}

@Component({
  selector: 'dialog-content-example-dialog',
  templateUrl: 'success-dialog-contents.html'
})
export class SuccessDialogContent {}
