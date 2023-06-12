import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWeatherComponent } from './add-weather/add-weather.component';
import { AllWeatherComponent } from './all-weather/all-weather.component';
import { EditWeatherComponent } from './edit-weather/edit-weather.component'
const routes: Routes = [
  {
    path: '',
    component: AllWeatherComponent
  },
  {
    path: 'add-weather',
    component: AddWeatherComponent
  },
  {
    path: 'edit-weather/:id',
    component: EditWeatherComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
