import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { WaterfeatureComponent } from './waterfeature/waterfeature.component';


import { NavbarComponent } from './navbar/navbar.component';
import { ProductService } from './product.service';
import { SharedModule } from './shared/shared.module';







@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    WaterfeatureComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, BrowserAnimationsModule, SharedModule,  
    
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
