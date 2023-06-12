import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WeatherCast } from '../weathercast'
import { AddWeatherCast } from '../addweathercast'
import { WeatherCastService } from '../weathercast.service'

@Component({
  selector: 'app-edit-weather',
  templateUrl: './edit-weather.component.html',
  styleUrls: ['./edit-weather.component.css']
})

export class EditWeatherComponent implements OnInit {
  summaryList = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  editID: number = 0;
  addweathercastForm: AddWeatherCast = {
    date: '',
    tempC: 0,
    summary: ''
  }

  weathercastForm: WeatherCast = {
    id:0,
    date: '',
    tempC: 0,
    tempF: 0,
    summary:''
  }

  constructor(
    private weatherCastService: WeatherCastService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      var id = Number(param.get('id'))
      this.editID = id;
      this.getById();
    })
    console.log(this.editID);
  }

  getById() {
    this.weatherCastService.getById(this.editID).subscribe((data) => {
      this.weathercastForm = data;
      this.addweathercastForm = {
        date: data.date,
        tempC: data.tempC,
        summary: data.summary
      }
    });
  }

  update() {
    this.weatherCastService.update(this.editID, this.addweathercastForm).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
