import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MatAutocompleteModule} from '@angular/material/autocomplete'

import { SearchbarComponent } from './searchbar/searchbar.component';
import { LandingPageRoutingModule } from './landingpage-routing.module';


@NgModule({
  declarations: [SearchbarComponent],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    LandingPageRoutingModule,
    MatIconModule,
    MatSelectModule,
    MatAutocompleteModule
  ],
  providers:[]
})

export class LandingpageModule { }
