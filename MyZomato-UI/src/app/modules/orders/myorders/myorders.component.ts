import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { IOrder } from 'src/app/core/models/order';
import { IProduct } from 'src/app/core/models/product';
import { ProductsApiService } from 'src/app/core/services/api-services/products-api.service';
import { RestaurantsApiService } from 'src/app/core/services/api-services/restaurants-api.service';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class MyordersComponent implements OnInit {
  isLoading:boolean=true;
  orders:IOrder[];
  displayedColumns: string[];
  displayedInnerColumns: string[];
  allProducts:IProduct[];

  constructor(private _restaurantService:RestaurantsApiService, private _productService:ProductsApiService) { 
    this.orders = [];
    this.allProducts = [];
    this.displayedColumns = ['Order Id', 'Transaction Id', 'Amount', 'Status', 'Restaurant', 'Order Date', 'Expand/Collapse'];
    this.displayedInnerColumns = ['Product', 'Quantity', 'Price'];
  }

  async ngOnInit(): Promise<void> {
    this._productService.getProductsForRestaurant(0).subscribe((result) => this.allProducts = result);
    this._restaurantService.getAllOrders().subscribe((result) => {this.orders = result; this.isLoading = false;});
    this.orders.map(o => o.orderProducts.map(op => op.productName = this.allProducts.filter(p => p.id == op.productId)[0].productName))
  }

  toggleExpand(order:IOrder){
    order.isExpanded = order.isExpanded == true ? false : true;
  }
}
