import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { IRestaurant } from 'src/app/core/models/restaurant';
import { RestaurantsApiService } from 'src/app/core/services/api-services/restaurants-api.service';
import { IpService } from 'src/app/core/services/api-services/ip-service.service';
import { ICity } from 'src/app/core/models/city';
import { Router } from '@angular/router';

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

  constructor(private _httpHelper:RestaurantsApiService, private _ipService:IpService, private router:Router) {
    this.allRestaurants = [],
    this.filteredList = [];
    this.allCities = [];
    this.isRestaurantDisabled = true;
    this.isCityDisabled = true;
    this.ip = "";
    this.city = "";
    this.defaultCity = 0;
  }

  async ngOnInit() {
    this.ip = await this.getIpAddress(); 
    this.city = await this.getLocation();
    await this.getAllCities();
    await this.populateDefaultCity()
  }

  async getIpAddress(){
    var ip = await this._ipService.getIpAddress();
                    //.then((response) => { ip = ip + response.ip;});
                    

    return ip;
  }

  async getLocation(){ //removing graphemes from range U+0300 → U+036F
    let fetchedCity = await this._ipService.getGeoLocation(this.ip);
    let parsedCity = fetchedCity.city != null ? "" + fetchedCity.city.normalize("NFD").replace(/[\u0300-\u036f]/g, "") : "Bhilai";
    return parsedCity;
  }

  async getAllCities(){
    let citiesResponse = await this._httpHelper.getCities();
    citiesResponse.map((city => this.allCities.push(city)));
  }

  async getAllRestaurants(cityId:number){
    this.allRestaurants = await this._httpHelper.getRestaurants(cityId);
}

  async populateDefaultCity(){

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

  async cityChanged(){
    
    this.isRestaurantDisabled = false;
    this.restaurantFormControl.enable();
    await this.getAllRestaurants(parseInt(this.cityFormControl.value));
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

  search(){
    console.log(this.router.url);
      if(this.restaurantFormControl.value != null && this.restaurantFormControl.value != '')
      {
          this.router.navigate(['products-for-restaurant/', this.filteredList.filter(rest => rest.name === this.restaurantFormControl.value)[0].id])
      }
      else
      {
          this.router.navigate(['/restaurants/restaurants-in-city/', this.cityFormControl.value]);
      }
  }
}
