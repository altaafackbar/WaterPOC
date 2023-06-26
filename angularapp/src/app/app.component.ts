import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AppService } from './app.service';
import { WaterLogFilters, WaterLog } from './app.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecasts?: WeatherForecast[];

  waterId = "";
  waterFeature = "";
  waterLocation = "";
  selectedFilters: WaterLogFilters = {}

  waterLogs: WaterLog[] = [];

  constructor(http: HttpClient, private readonly _appService: AppService) {

    this._appService = _appService;

    
    http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  title = 'angularapp';


  getWaterLogs() {

    this._appService.getWaterLog(this.waterId, this.waterFeature, this.waterLocation).subscribe(d => {
      this.setWaterData(d);
    });
    console.log(this.waterLogs);
  }

  setWaterData(data: WaterLog[]) {

    this.waterLogs = data;

  }
}



interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
