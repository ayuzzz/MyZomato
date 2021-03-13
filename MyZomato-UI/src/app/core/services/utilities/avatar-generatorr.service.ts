import { Injectable } from '@angular/core';
import { IUser } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class AvatarGeneratorrService {
  currentUser:IUser = {userId:1}

  constructor() { 
    this.currentUser = JSON.parse(sessionStorage.getItem('currentUser')?.toString() as string) as IUser;
  }

  getInitials(){
    var userName:string = this.currentUser.name as string;
    var splitName:string[] = userName?.split(' ') as string[];
    var initials:string = "";

    if(splitName?.length == 1)
    {
      initials += splitName[0][0];
      initials += splitName[0][1];
    }
    else if(splitName?.length == 2)
    {
      splitName.forEach((name) => {initials += name[0]});
    }
    else if(splitName?.length > 2)
    {
      for(var i = 0; i < 2; i++)
      {
        initials += splitName[0][0];
      }
    }

    return initials;
  }
}
