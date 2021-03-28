import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Observable } from "rxjs";
import { IRestaurant } from "../../models/restaurant";
import { ICity } from "../../models/city";
import { RestaurantsApiUri } from "../../uri/restaurants-api-uri";
import { IOrder } from "../../models/order";

@Injectable()
export class RestaurantsApiService{

    constructor(private _http:HttpClient) {}

    async getRestaurants(cityId:number):Promise<IRestaurant[]>{
        // const options = {
        //     responseType: 'text' as const,
        //   };

        return await this._http.get<IRestaurant[]>(RestaurantsApiUri.GET_RESTAURANTS_FORCITY+cityId.toString()).toPromise();
                    
    }

    async getCities():Promise<ICity[]>{
      // const options = {
      //     responseType: 'text' as const,
      //   };

      return await this._http.get<ICity[]>(RestaurantsApiUri.GET_CITIES).toPromise();
                  
  }

    async getAllOrders():Promise<IOrder[]>{
      // const options = {
      //     responseType: 'text' as const,
      //   };

      return await this._http.get<IOrder[]>(RestaurantsApiUri.GET_ALL_ORDERS).toPromise();
                  
  }
}