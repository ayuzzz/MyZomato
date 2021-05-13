import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { MsalModule, MsalInterceptor } from '@azure/msal-angular';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RestaurantsApiService } from './core/services/api-services/restaurants-api.service';
import { IpService } from './core/services/api-services/ip-service.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ProductsAppRoutingModule } from './modules/products/products-app-routing.module';
import { CartComponent } from './modules/landingpage/cart/cart.component';
import {MatBadgeModule} from '@angular/material/badge';
import { OrdersAppRoutingModule } from './modules/orders/orders-app-routing.module';
import { UserAppRoutingModule } from './modules/user/user-app-routing.module';

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
    MatBadgeModule,
    MatSlideToggleModule,
    OrdersAppRoutingModule,
    UserAppRoutingModule
  ],
  providers: [
    RestaurantsApiService,
    IpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
