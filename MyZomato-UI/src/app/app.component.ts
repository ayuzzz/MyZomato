import { Component } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { UserAuthService } from './core/services/api-services/user-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  menuToggled:boolean = false;
  title = 'MyZomato-UI';
  user:string;

  constructor(private _authService: MsalService, private _userAuthService:UserAuthService)
  {
    this.user = 'Login';
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

  login() {   
    this._authService.loginRedirect({
      extraScopesToConsent: ["user.read", "openid", "profile"]
    });  
    
    this.user = this._authService.getAccount().userName;
    //this._userAuthService.getProfile().subscribe((response) => this.user = response.displayName)    
  }

}
