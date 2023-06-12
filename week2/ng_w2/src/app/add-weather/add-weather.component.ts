import { Component , OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { WeatherCast } from '../weathercast'
import { AddWeatherCast } from '../addweathercast'
import { WeatherCastService } from '../weathercast.service'

@Component({
  selector: 'app-add-weather',
  templateUrl: './add-weather.component.html',
  styleUrls: ['./add-weather.component.css']
})

export class AddWeatherComponent implements OnInit{
  summaryList = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  weathercastForm: AddWeatherCast = {
    date:'',
    tempC: 0,
    summary:'Freezing'
  }
  constructor(
    private weatherCastService: WeatherCastService,
    private router: Router
  ) { }

  ngOnInit(): void { }

  create() {
    const now = new Date();
    this.weathercastForm.date = now.toISOString();
    this.weatherCastService.create(this.weathercastForm).subscribe((data) => {
      console.log(data);
      this.router.navigate(['/']);
    });
  }
}
