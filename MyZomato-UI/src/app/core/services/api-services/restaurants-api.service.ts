import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Observable } from "rxjs";
import { IRestaurant } from "../../models/restaurant";
import { ICity } from "../../models/city";
import { RestaurantsApiUri } from "../../uri/restaurants-api-uri";

@Injectable()
export class RestaurantsApiService{

    constructor(private _http:HttpClient) {}

    getRestaurants(cityId:number):Observable<IRestaurant[]>{
        // const options = {
        //     responseType: 'text' as const,
        //   };

        return this._http.get<IRestaurant[]>(RestaurantsApiUri.GET_RESTAURANTS_FORCITY+cityId.toString());
                    
    }

    getCities():Observable<ICity[]>{
      // const options = {
      //     responseType: 'text' as const,
      //   };

      return this._http.get<ICity[]>(RestaurantsApiUri.GET_CITIES);
                  
  }
}