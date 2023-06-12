import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherCast } from './weathercast';
import { AddWeatherCast } from './addweathercast';

@Injectable({
  providedIn: 'root',
})
export class WeatherCastService {
  constructor(private httpClient: HttpClient) { }
  get(): Observable<WeatherCast[]> {
    return this.httpClient.get<WeatherCast[]>('https://localhost:44372/WeatherForecast');
  }

  create(payload: AddWeatherCast) {
    return this.httpClient.post<WeatherCast>(
      'https://localhost:44372/WeatherForecast',
      payload
    );
  }

  getById(id: number): Observable<WeatherCast> {
    return this.httpClient.get<WeatherCast>('https://localhost:44372/WeatherForecast/'+id);
  }

  getFilter(filter: string): Observable<WeatherCast[]> {
    return this.httpClient.get<WeatherCast[]>('https://localhost:44372/WeatherForecast/filter/'+filter);
  }

  update(id:number,payload: AddWeatherCast) {
    return this.httpClient.put<WeatherCast>(
      'https://localhost:44372/WeatherForecast/'+id,
      payload
    );
  }

  delete(id: number) {
    return this.httpClient.delete('https://localhost:44372/WeatherForecast/'+id);
  }
}
