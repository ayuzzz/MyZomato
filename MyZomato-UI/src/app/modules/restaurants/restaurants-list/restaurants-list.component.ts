import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IRestaurant } from 'src/app/core/models/restaurant';
import { RestaurantsApiService } from 'src/app/core/services/api-services/restaurants-api.service';

@Component({
  selector: 'app-restaurants-list',
  templateUrl: './restaurants-list.component.html',
  styleUrls: ['./restaurants-list.component.css']
})
export class RestaurantsListComponent implements OnInit {

  responseList: IRestaurant[];

  constructor(private _activatedRoute:ActivatedRoute, private _restaurantsApiService:RestaurantsApiService) { 
    this.responseList = [];
  }

  ngOnInit(): void {
    let city:number = parseInt(this._activatedRoute.snapshot.paramMap.get('cityId') as string);
     this.getAllRestaurants(city);
  }

  getAllRestaurants(cityId:number){
    this._restaurantsApiService.getRestaurants(cityId)
    .subscribe((result) => this.responseList = result)
}

}
