import { Component, HostBinding} from '@angular/core';
import {OverlayContainer} from '@angular/cdk/overlay'
import { UserApiService } from './core/services/api-services/user-api.service';
import { IUser } from './core/models/user';
import { AvatarGeneratorrService } from './core/services/utilities/avatar-generatorr.service';

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
  currentUser:IUser = {userId:1};
  userInitials:string = "";
  avatarColor:string = "";

  constructor(private _userService:UserApiService, private _avatarGenerator:AvatarGeneratorrService) {

    this._userService.getUserDetails(1).subscribe((response) => {this.currentUser = response[0];
       
        sessionStorage.setItem('currentUser', JSON.stringify(this.currentUser));
        this.userInitials = _avatarGenerator.getInitials();
        this.avatarColor = _avatarGenerator.randomizeColors();
      });
    
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