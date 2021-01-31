import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  private readonly graphMeEndpoint:string;
  

  constructor(private _httpClient:HttpClient) { 
    this.graphMeEndpoint = "https://graph.microsoft.com/v1.0/me";
  }

  getProfile():Observable<IUser> {
    return this._httpClient.get<IUser>(this.graphMeEndpoint);
  }
}
