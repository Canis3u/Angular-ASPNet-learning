import { Component, OnInit, inject } from '@angular/core';
import { WeatherCast } from '../weathercast'
import { WeatherCastService } from '../weathercast.service'

@Component({
  selector: 'app-all-weather',
  templateUrl: './all-weather.component.html',
  styleUrls: ['./all-weather.component.css']
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
  ) { }
  
  get() {
    this.weatherCastService.get().subscribe((data) => {
      this.allWeatherSrc = data;
      this.viewWeatherSrc = this.allWeatherSrc;
    });
  }

  delete(id: number) {
    this.weatherCastService.delete(id).subscribe((data:any) => {
      this.allWeatherSrc = this.allWeatherSrc.filter(
        (_) => _.id !== id
      );
      this.viewWeatherSrc = this.allWeatherSrc;
    });
  }

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

  cancel() {
    this.get()
    this.filter = '';
  }


  sort(col:string) {
    console.log(col);
    if (col == this.last)
      this.direction = !this.direction;
    else
      this.direction = true;
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
