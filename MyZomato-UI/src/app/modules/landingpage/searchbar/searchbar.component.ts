import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IRestaurant } from 'src/app/core/models/restaurant';
import { RestaurantsApiService } from 'src/app/core/services/api-services/restaurants-api.service';
import {map, startWith} from 'rxjs/operators'
import { RestaurantsApiUri } from 'src/app/core/uri/restaurants-api-uri';
import { IpService } from 'src/app/core/services/api-services/ip-service.service';
import { ICity } from 'src/app/core/models/city';

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {

  allRestaurants:IRestaurant[];
  filteredList:IRestaurant[];
  allCities:ICity[];
  restaurantFormControl = new FormControl({value:'', disabled:true});
  cityFormControl = new FormControl({value:'', disabled:true});

  isRestaurantDisabled:boolean;
  isCityDisabled:boolean;
  ip:string;
  city:string;
  defaultCity:number;

  constructor(private _httpHelper:RestaurantsApiService, private _ipService:IpService) {
    this.allRestaurants = [],
    this.filteredList = [];
    this.allCities = [];
    this.isRestaurantDisabled = true;
    this.isCityDisabled = true;
    this.ip = "";
    this.city = "";
    this.defaultCity = 0;
  }

  ngOnInit() {
    this.getIpAddress(); 
  }

  getIpAddress(){
    this._ipService.getIpAddress()
                    .subscribe((response) => {this.ip += response.ip; this.getLocation()});
  }

  getLocation():void{ //removing graphemes from range U+0300 → U+036F
    this._ipService.getGeoLocation(this.ip)
                    .subscribe((response) => {this.city += response.city.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
                                                this.getAllCities();
                                              });                     
  }

  getAllCities(){
    this._httpHelper.getCities()
                    .subscribe((response) => {response.map((city => this.allCities.push(city)));
                                              this.populateDefaultCity()})
  }

  populateDefaultCity(){

    if(this.allCities.some(c => c.name.toLowerCase() == this.city.toLowerCase()))
    {
      this.defaultCity = this.allCities.filter(c => c.name.toLowerCase() == this.city.toLowerCase())[0].id;
    }

    if(this.defaultCity != 0){
      this.cityFormControl.setValue(this.defaultCity);
      this.isCityDisabled = false;
      this.cityFormControl.enable();
      this.cityChanged();
    }
    else{
      this.isCityDisabled = false;
      this.cityFormControl.enable();
    }
       
  }

  getAllRestaurants(cityId:number){
      this._httpHelper.getRestaurants(cityId)
      .subscribe((result) => this.allRestaurants = result)
  }

  cityChanged(){
    
    this.isRestaurantDisabled = false;
    this.restaurantFormControl.enable();
    this.getAllRestaurants(parseInt(this.cityFormControl.value));
    this.changeFilteredList();
    
  }

  changeFilteredList(){
    this.filteredList = this.filterList(this.restaurantFormControl.value)
  }

  filterList(value:string):IRestaurant[]{
    const input = value.toLowerCase();
    return this.allRestaurants.filter(restaurant => restaurant.name.toLowerCase().indexOf(input) === 0 
                                      && restaurant.cityId == this.cityFormControl.value);
  }
}
