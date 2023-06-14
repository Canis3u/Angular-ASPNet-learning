import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ConfirmationService } from 'primeng/api';

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

  constructor(
    private weatherCastService: WeatherCastService,
    private router: Router,
    private route: ActivatedRoute,
    private confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      this.editID = Number(param.get('id'))
      this.getById();
    })
  }

  getById() {
    this.weatherCastService.getById(this.editID).subscribe((data) => {
      this.addweathercastForm = {
        date: data.date,
        tempC: data.tempC,
        summary: data.summary
      }
      console.log(this.addweathercastForm.summary);
    });
  }

  confirmupdate() {
    this.confirmationService.confirm({
      message: 'Do you want to update this record?',
      header: 'Update Confirmation',
      accept: () => {
        this.update();
      }
    });
  }

  update() {
    this.weatherCastService.update(this.editID, this.addweathercastForm).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
