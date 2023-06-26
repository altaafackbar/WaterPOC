import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WaterLog, WaterLogFilters } from './app.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {


  private base_url = "https://localhost:7243/Water";
  private _url = "";

  constructor(private httpClient: HttpClient) { }



  getWaterLog(id: string, featureName: string, locationDescription: string): Observable<WaterLog[]> {

    this._url = `${this.base_url}/getWater?`;

    if (id != null) {
      this._url = `${this._url}id=${id}`
    }
    if (featureName != null) {
      this._url = `${this._url}&featureName=${featureName}`
    }
    if (locationDescription != null) {
      this._url = `${this._url}&locationDescription=${locationDescription}`
    }
    console.log(this._url);
    return this.httpClient.get<WaterLog[]>(this._url);
  }
}
