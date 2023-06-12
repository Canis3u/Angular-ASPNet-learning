import { Component, OnInit } from '@angular/core';

import weatherData from './weather.json';

interface Weather {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  _weather: Weather[] = weatherData;
  _summary = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  constructor() { }
  ngOnInit() {}

  addBtn() {
    const now = new Date();
    const w = {} as Weather;
    w.date = now.toISOString();
    w.temperatureC = Math.floor(Math.random() * 70 -30)
    w.temperatureF = w.temperatureC * 0.5556 + 32
    w.summary = this._summary[Math.floor(Math.random() * 10)];
    this._weather.push(w)
  }

  delBtn() {
    this._weather.pop();
  }
}
