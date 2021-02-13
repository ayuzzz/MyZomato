import { Component, HostBinding} from '@angular/core';
import {OverlayContainer} from '@angular/cdk/overlay'

const THEME_DARKNESS_SUFFIX = `-dark`

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  menuToggled:boolean = false;
  title = 'MyZomato-UI';
  isDarkTheme:boolean = false;

  constructor(private overlayContainer: OverlayContainer) { 
    var darkTheme = JSON.parse(localStorage.getItem('isDark') as string) as boolean;
    if(darkTheme === null)
    {
      localStorage.setItem('isDark', JSON.stringify(false));      
    }    
    document.body.classList.remove('mat-app-background');
  }

  toggleMenu(sidemenu:any){
    sidemenu.toggle();
    if(this.menuToggled === false){
      this.menuToggled = true;
    }
    else{
      this.menuToggled = false;
    }
  }

  toggleTheme(isDark:boolean){
    this.isDarkTheme = !isDark;
    localStorage.setItem('isDark', JSON.stringify(this.isDarkTheme));
    if(this.isDarkTheme)
    {
      document.body.classList.add('mat-app-background');  
    }    
    else
    {
      document.body.classList.remove('mat-app-background');
    }
  }
}