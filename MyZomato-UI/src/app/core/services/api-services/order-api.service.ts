import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {IOrder} from '../../models/order';
import {OrdersApiUri} from '../../uri/orders-api-uri';

@Injectable({
  providedIn: 'root'
})
export class OrderApiService {

  constructor(private _httpClient:HttpClient) { }

  createOrder(order:IOrder):Observable<boolean>{
    return this._httpClient.post<boolean>(OrdersApiUri.CREATE_ORDER, order);
  }
}
