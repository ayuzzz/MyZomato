import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchbarComponent } from './searchbar/searchbar.component';


const routes: Routes = [
  {path:'', component:SearchbarComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LandingPageRoutingModule { }
