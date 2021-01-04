import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IRestaurant } from 'src/app/core/models/restaurant';
import { LandingPageApiService } from 'src/app/core/services/landingpage-api-services/landingpage-api-service';
import {map, startWith} from 'rxjs/operators'
import { LandingPageApiUri } from 'src/app/core/services/landingpage-api-services/landingpage-uri';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {

  allRestaurants:IRestaurant[] = [];
  filteredList:IRestaurant[] = [];
  restaurantFormControl = new FormControl({value:'', disabled:true});
  cityFormControl = new FormControl();

  isDisabled:boolean;

  constructor(private _httpHelper:LandingPageApiService) {
    this.isDisabled = true;
  }

  ngOnInit(): void {
    
  }

  getAllRestaurants(cityId:number){
      this._httpHelper.getRestaurants(LandingPageApiUri.GET_RESTAURANTS+cityId.toString())
      .subscribe((result) => this.allRestaurants = result)
  }

  cityChanged(){
    if(this.cityFormControl.value){
      this.isDisabled = false;
      this.restaurantFormControl.enable();

      this.getAllRestaurants(parseInt(this.cityFormControl.value));
    }
    else{
      this.isDisabled = true;
      this.restaurantFormControl.disable();
    }
  }

  changeFilteredList(){
    this.filteredList = this.filterList(this.restaurantFormControl.value)
  }

  filterList(value:string):IRestaurant[]{
    const input = value.toLowerCase();

    return this.allRestaurants.filter(restaurant => restaurant.name.toLowerCase().indexOf(input) === 0)
  }
}
