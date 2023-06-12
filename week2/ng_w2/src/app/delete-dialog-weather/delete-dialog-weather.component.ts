import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { WeatherCastService } from '../weathercast.service'

@Component({
  selector: 'app-delete-dialog-weather',
  templateUrl: './delete-dialog-weather.component.html',
  styleUrls: ['./delete-dialog-weather.component.css']
})

export class DeleteDialogWeatherComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogWeatherComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private weatherCastService: WeatherCastService
  ) { }

  ngOnInit(): void { }

  confirmDelete() {
    this.weatherCastService.delete(this.data.id).subscribe(() => {
      this.dialogRef.close(this.data.id);
    });
  }

}

