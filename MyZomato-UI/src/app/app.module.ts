import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MsalModule, MsalInterceptor } from '@azure/msal-angular';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';

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
import { UserAuthService } from './core/services/api-services/user-auth.service';

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
    MsalModule.forRoot(
    {
      auth: {
        clientId: 'Enter_the_Application_Id_here', // This is your client ID
        //authority: `${Cloud_Instance_Id}/${Tenant_Info}`, // This is your tenant ID
        authority: 'Cloud_Instance_Id}/{Tenant_Info}',
        redirectUri: 'http://localhost:4200/'// This is your redirect URI
      },
      cache: {
        cacheLocation: 'localStorage'
      },
    }, 
    {
      consentScopes: [
        'user.read',
        'openid',
        'profile',
      ],
      unprotectedResources: [],
      protectedResourceMap: [
        ['https://graph.microsoft.com/v1.0/me', ['user.read']]
      ],
      extraQueryParameters: {}
    })
  ],
  providers: [
    RestaurantsApiService,
    IpService,
    UserAuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
