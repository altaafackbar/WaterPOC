import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExcelModule, GridModule, PDFModule } from '@progress/kendo-angular-grid';
import { MatTableModule } from '@angular/material/table';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { WaterfeatureComponent } from '../waterfeature/waterfeature.component';


@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule, 
  ],
  exports: [
    GridModule, MatTableModule, DialogsModule, InputsModule, ButtonsModule, PDFModule, ExcelModule,
    
  ]
})
export class SharedModule { }
