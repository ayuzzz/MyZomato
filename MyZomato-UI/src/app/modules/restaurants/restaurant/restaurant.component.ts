import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IRestaurant } from 'src/app/core/models/restaurant';
import { ProductsApiService } from 'src/app/core/services/api-services/products-api.service';
import { ProductsApiUri } from 'src/app/core/uri/products-api-uri';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})

export class RestaurantComponent implements OnInit {

  @Input()
  public _restaurant:IRestaurant;

  constructor(private _router:Router) {
    this._restaurant = {} as IRestaurant;
   }

  ngOnInit(): void {
  }

  public restaurantSelected(){
    if(this._restaurant != null){
      console.log("Url : " + "/products/products-for-restaurant/" + this._restaurant.id);
      this._router.navigate(["/products/products-for-restaurant", this._restaurant.id]);
    }
  }
}
