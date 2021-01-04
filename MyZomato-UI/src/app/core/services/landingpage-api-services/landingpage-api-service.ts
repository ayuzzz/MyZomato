import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Observable } from "rxjs";
import { IRestaurant } from "../../models/restaurant";

@Injectable()
export class LandingPageApiService{

    constructor(private _http:HttpClient) {}

    getRestaurants(url:string):Observable<IRestaurant[]>{
        // const options = {
        //     responseType: 'text' as const,
        //   };

        return this._http.get<IRestaurant[]>(url);
                    
    }

}