import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../../models/IProduct';
import { ProductsApiUri } from '../../uri/products-api-uri';

@Injectable({
  providedIn: 'root'
})
export class ProductsApiService {

  constructor(private _httpClient:HttpClient, ) { }

  getProductsForRestaurant(restaurantId:number):Observable<IProduct[]>{
    
    return this._httpClient.get<IProduct[]>(ProductsApiUri.GET_PRODUCTS_FOR_RESTAURANT + restaurantId.toString());

  }
}
