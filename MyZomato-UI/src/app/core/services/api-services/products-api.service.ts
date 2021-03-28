import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../../models/product';
import { ProductsApiUri } from '../../uri/products-api-uri';

@Injectable({
  providedIn: 'root'
})
export class ProductsApiService {

  constructor(private _httpClient:HttpClient, ) { }

  async getProductsForRestaurant(restaurantId:number):Promise<IProduct[]>{
    
    return await this._httpClient.get<IProduct[]>(ProductsApiUri.GET_PRODUCTS_FOR_RESTAURANT + restaurantId.toString()).toPromise();

  }
}
