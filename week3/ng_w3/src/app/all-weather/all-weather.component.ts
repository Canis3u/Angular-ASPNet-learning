import { Component, OnInit, inject } from '@angular/core';

import { ConfirmationService } from 'primeng/api';

import { WeatherCast } from '../weathercast'
import { WeatherCastService } from '../weathercast.service'

@Component({
  selector: 'app-all-weather',
  templateUrl: './all-weather.component.html',
  styleUrls: ['./all-weather.component.css'],
})

export class AllWeatherComponent implements OnInit{
  allWeatherSrc: WeatherCast[] = [];
  viewWeatherSrc: WeatherCast[] = [];
  displayedColumns: string[] = ['Id', 'Date', 'TempC', 'TempF', 'Summary'];
  summaryList = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  filter: string = '';
  direction = true;
  last = '';

  ngOnInit(): void {
    this.get()
  }

  constructor(
    private weatherCastService: WeatherCastService,
    private confirmationService: ConfirmationService
  ) { }

  //button click
  get() {
    this.weatherCastService.get().subscribe((data) => {
      this.allWeatherSrc = data;
      this.viewWeatherSrc = this.allWeatherSrc;
    });
  }

  confirmdelete(id:number) {
    console.log(id);
    this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      accept: () => {
        this.delete(id);
      }
    });
  }

  //button click
  delete(id: number) {
    this.weatherCastService.delete(id).subscribe((data:any) => {
      this.allWeatherSrc = this.allWeatherSrc.filter(
        (_) => _.id !== id
      );
      this.viewWeatherSrc = this.allWeatherSrc;
    });
  }

  //button click
  filterby() {
    if (this.filter == '') {
      alert("Selet a filter first!");
      return;
    }
    this.weatherCastService.getFilter(this.filter).subscribe((data) => {
      this.allWeatherSrc = data;
      this.viewWeatherSrc = this.allWeatherSrc;
    });
  }

  //button click
  cancel() {
    this.get()
    this.filter = '';
  }

  //button click
  sort(col:string) {
    console.log(col);
    if (col == this.last)
      this.direction = !this.direction; //若重複點擊, 判定為升冪降冪轉換
    else
      this.direction = true; //若是新的, 則重置sort排序
    const isAsc = this.direction;
    const data = this.allWeatherSrc.slice();
    this.viewWeatherSrc = data.sort((a, b) => {
      this.last = col;
      switch (col) {
        case 'Id':
          return compare(a.id, b.id, isAsc);
        case 'Date':
          return compare(a.date, b.date, isAsc);
        case 'TempC':
          return compare(a.tempC, b.tempC, isAsc);
        case 'TempF':
          return compare(a.tempF, b.tempF, isAsc);
        case 'Summary':
          return compare(a.summary, b.summary, isAsc);
        default:
          return 0;
      }
    });
  }
}
function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
