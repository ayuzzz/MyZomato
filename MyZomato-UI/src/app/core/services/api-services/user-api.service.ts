import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../../models/user';
import { UserApiUri } from '../../uri/user-api-uri';

@Injectable({
  providedIn: 'root'
})
export class UserApiService {

  constructor(private _httpClient:HttpClient) { }

  async getUserDetails(userId:number):Promise<IUser[]>{
    return await this._httpClient.get<IUser[]>(UserApiUri.GET_USERDETAILS + userId.toString()).toPromise();
  }
}
