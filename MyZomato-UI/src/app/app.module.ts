import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RestaurantsApiService } from './core/services/api-services/restaurants-api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { IpService } from './core/services/api-services/ip-service.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
    ],
  providers: [RestaurantsApiService, IpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
