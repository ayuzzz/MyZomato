import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RestaurantsApiService } from './core/services/api-services/restaurants-api.service';
import { HttpClientModule } from '@angular/common/http';
import { IpService } from './core/services/api-services/ip-service.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ProductsAppRoutingModule } from './modules/products/products-app-routing.module';
import { CartComponent } from './modules/landingpage/cart/cart.component';
import {MatBadgeModule} from '@angular/material/badge';

@NgModule({
  declarations: [
    AppComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatToolbarModule,
    ProductsAppRoutingModule,
    MatBadgeModule
    ],
  providers: [RestaurantsApiService, IpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
