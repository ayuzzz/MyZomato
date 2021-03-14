import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { IOrder, IOrderProduct } from 'src/app/core/models/order';
import {IProduct} from 'src/app/core/models/product';
import { CartUpdateService } from 'src/app/core/services/api-services/cart-update.service';
import { OrderApiService } from 'src/app/core/services/api-services/order-api.service';


@Component({
  selector: 'app-success-dialog',
  templateUrl: './success-dialog.component.html',
  styleUrls: ['./success-dialog.component.css']
})
export class SuccessDialogComponent implements OnInit {

  constructor(public dialog: MatDialog, private router:Router, private _orderApiService:OrderApiService,
    private _cartUpdateService:CartUpdateService) { }

  ngOnInit(): void {
  }

  openSuccessDialog(){    
    this._orderApiService.createOrder(this.createOrderObject()).subscribe(data => {});
    localStorage.removeItem('restaurantId');
    localStorage.removeItem('productsInCart');

    const successDialogReference = this.dialog.open(SuccessDialogContent);
    successDialogReference.afterClosed().subscribe(result => {
      this._cartUpdateService.cartQuantity.next(0);
      this.router.navigate(['landingpage']);
    });
  }

  createOrderObject():IOrder{
    let order:IOrder = new Object() as IOrder;
    order.restaurantId = JSON.parse(localStorage.getItem('restaurantId') as string) as number;

    order.orderProducts = [] as IOrderProduct[];

    let orderProducts = JSON.parse(localStorage.getItem('productsInCart') as string) as IProduct[];
    orderProducts.forEach(product => {
      order.orderProducts.push({productId:product.id, productName:"", quantity:product.quantity, price:product.price*product.quantity});
    });

    return order;
  }
}

@Component({
  selector: 'dialog-content-example-dialog',
  templateUrl: 'success-dialog-contents.html'
})
export class SuccessDialogContent {}
