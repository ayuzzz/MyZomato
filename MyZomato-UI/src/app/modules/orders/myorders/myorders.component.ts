import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/core/models/order';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css']
})
export class MyordersComponent implements OnInit {

  orders:IOrder[];
  displayedColumns: string[];

  constructor() { 
    this.orders = [{id:10012, transactionId:'88B7900E-4538-4BD8-B4E1-E3D839D06520', amount:220, status:'Delivered', restaurant:'ABC Cafe', restaurantId:0, orderProducts:[] }];
    this.displayedColumns = ['Order Id', 'Transaction Id', 'Amount', 'Status', 'Restaurant', 'Order Date'];
  }

  ngOnInit(): void {
  }

}
