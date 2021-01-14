import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MatAutocompleteModule} from '@angular/material/autocomplete'
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';

import { SearchbarComponent } from './searchbar/searchbar.component';
import { LandingPageRoutingModule } from './landingpage-routing.module';
import { CheckoutComponent } from './checkout/checkout.component';


@NgModule({
  declarations: [SearchbarComponent, CheckoutComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    LandingPageRoutingModule,
    MatIconModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatTableModule
  ],
  providers:[]
})

export class LandingpageModule { }
