import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AllWeatherComponent } from './all-weather/all-weather.component';
import { AddWeatherComponent } from './add-weather/add-weather.component';
import { EditWeatherComponent } from './edit-weather/edit-weather.component';
import { DeleteDialogWeatherComponent } from './delete-dialog-weather/delete-dialog-weather.component';

@NgModule({
  declarations: [
    AppComponent,
    AllWeatherComponent,
    AddWeatherComponent,
    EditWeatherComponent,
    DeleteDialogWeatherComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
