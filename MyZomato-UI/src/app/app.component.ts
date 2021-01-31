import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  menuToggled:boolean = false;
  title = 'MyZomato-UI';

  constructor() { }

  toggleMenu(sidemenu:any){
    sidemenu.toggle();
    if(this.menuToggled === false){
      this.menuToggled = true;
    }
    else{
      this.menuToggled = false;
    }
  }
}
