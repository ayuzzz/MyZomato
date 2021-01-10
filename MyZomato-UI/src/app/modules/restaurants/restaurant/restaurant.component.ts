import { Component, Input, OnInit } from '@angular/core';
import { IRestaurant } from 'src/app/core/models/restaurant';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})

export class RestaurantComponent implements OnInit {

  @Input()
  public _restaurant:IRestaurant;

  constructor() {
    this._restaurant = {} as IRestaurant;
   }

  ngOnInit(): void {
  }

}
