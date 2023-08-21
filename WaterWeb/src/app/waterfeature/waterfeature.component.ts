import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { WaterLogFilters, WaterLog } from '../app.models';
import { SortDescriptor } from '@progress/kendo-data-query';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs';
import { ProductService } from '../product.service';
import { products } from '../data.products'
import { SVGIcon, fileExcelIcon, filePdfIcon } from "@progress/kendo-svg-icons";
import { WaterfeatureService } from './waterfeature.service';

@Component({
  selector: 'app-waterfeature',
  templateUrl: './waterfeature.component.html',
  styleUrls: ['./waterfeature.component.css']
})
export class WaterfeatureComponent {
  public filePdfIcon: SVGIcon = filePdfIcon;
  public fileExcelIcon: SVGIcon = fileExcelIcon;
  waterId = "";
  waterFeature = "";
  waterLocation = "";
  selectedFilters: WaterLogFilters = {}

  resultCount = "";

  waterLogs: WaterLog[] = [];


  public gridItems!: Observable<GridDataResult>;
  public gridData: any[] = products;
  public pageSize: number = 10;
  public skip: number = 0;
  public sortDescriptor: SortDescriptor[] = [];
  public filterTerm: number = 0;

  public opened = false;
  public windowWidth = 500;
  public windowHeight = window.innerHeight;

  public windowTop = 0;
  public windowLeft = 950;

  public toggle(isOpened: boolean): void {
    this.opened = isOpened;
  }

  constructor(http: HttpClient, private readonly _waterService: WaterfeatureService, private service: ProductService) {

    this._waterService = _waterService;


    this.loadGridItems();

  }

  title = 'angularapp';


  getWaterLogs() {

    this._waterService.getWaterLog(this.waterId, this.waterFeature, this.waterLocation).subscribe(d => {
      this.setWaterData(d);
    });
    console.log(this.waterLogs);
  }

  setWaterData(data: WaterLog[]) {

    this.waterLogs = data;
    this.resultCount = data.length.toString();

  }

  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.loadGridItems();
  }

  public handleSortChange(descriptor: SortDescriptor[]): void {
    this.sortDescriptor = descriptor;
    this.loadGridItems();
  }

  private loadGridItems(): void {
    this.gridItems = this.service.getProducts(
      this.skip,
      this.pageSize,
      this.sortDescriptor,
      this.filterTerm
    );
    this.gridItems.subscribe()
  }
}
