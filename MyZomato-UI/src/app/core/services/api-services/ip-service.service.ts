import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {IpApiUri} from '../../uri/ip-api-uri';

@Injectable()
export class IpService {
  private readonly ACCESS_KEY:string;

  constructor(private _http:HttpClient){ 
    this.ACCESS_KEY = "789e1f85712033e827b58e0445a7125f";
  }

  async getIpAddress():Promise<any>
  {
    return await this._http.get(IpApiUri.GET_IP_ADDRESS).toPromise();
  }

  async getGeoLocation(ipAddress:string):Promise<any>{
    let url = IpApiUri.GET_GEOLOCATION_BASE + ipAddress + "?access_key=" + this.ACCESS_KEY;

    return await this._http.get(url).toPromise();
  }
}
