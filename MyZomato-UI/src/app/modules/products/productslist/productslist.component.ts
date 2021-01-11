import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/core/models/IProduct';
import { ProductsApiService } from 'src/app/core/services/api-services/products-api.service';

@Component({
  selector: 'app-productslist',
  templateUrl: './productslist.component.html',
  styleUrls: ['./productslist.component.css']
})
export class ProductslistComponent implements OnInit {

  responseList:IProduct[];

  constructor(private _router:ActivatedRoute, private _productApiService:ProductsApiService) { 
    this.responseList = [];
  }


  ngOnInit(): void { 
    let restaurantId = parseInt(this._router.snapshot.paramMap.get("restaurantId") as string);

    this.getProductsForRestaurant(restaurantId);
  }

  getProductsForRestaurant(restaurantId:number){
    this._productApiService.getProductsForRestaurant(restaurantId).subscribe(
      (response) => this.responseList = response);

  }   

}
