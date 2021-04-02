import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IUser } from 'src/app/core/models/user';
import { UserApiService } from 'src/app/core/services/api-services/user-api.service';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {

  userDetails:IUser[];
  userId:number;
  userFormGroup:FormGroup

  constructor(private _userService:UserApiService) {
    this.userId = 1
    this.userDetails = []
    this.userFormGroup = new FormGroup({
      'name' : new FormControl(''),
      'email' : new FormControl(''),
      'contactNumber' : new FormControl('')
    })    
   }

  async ngOnInit() {
    this.userDetails = await this._userService.getUserDetails(this.userId);
    this.userFormGroup.get('name')?.setValue(this.userDetails[0].name);
    this.userFormGroup.get('email')?.setValue(this.userDetails[0].email);
    this.userFormGroup.get('contactNumber')?.setValue(this.userDetails[0].contactNumber);
  }
}
