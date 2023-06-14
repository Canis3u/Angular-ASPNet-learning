import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherCast } from './weathercast';
import { AddWeatherCast } from './addweathercast';

@Injectable({
  providedIn: 'root',
})
export class WeatherCastService {
  constructor(private httpClient: HttpClient) { }
  get(): Observable<WeatherCast[]> {
    return this.httpClient.get<WeatherCast[]>('https://localhost:44372/WeatherForecast',{headers:this.get_headers()});
  }

  create(payload: AddWeatherCast) {
    return this.httpClient.post<WeatherCast>(
      'https://localhost:44372/WeatherForecast',
      payload,{headers:this.get_headers()}
    );
  }

  getById(id: number): Observable<WeatherCast> {
    return this.httpClient.get<WeatherCast>('https://localhost:44372/WeatherForecast/'+id,{headers:this.get_headers()});
  }

  getFilter(filter: string): Observable<WeatherCast[]> {
    return this.httpClient.get<WeatherCast[]>('https://localhost:44372/WeatherForecast/filter/'+filter,{headers:this.get_headers()});
  }

  update(id:number,payload: AddWeatherCast) {
    return this.httpClient.put<WeatherCast>(
      'https://localhost:44372/WeatherForecast/'+id,
      payload,{headers:this.get_headers()}
    );
  }

  delete(id: number) {
    return this.httpClient.delete('https://localhost:44372/WeatherForecast/'+id,{headers:this.get_headers()});
  }

  private get_headers() {
    let headers = new HttpHeaders();
    headers=headers.append('content-type','application/json')
    headers=headers.append('Access-Control-Allow-Origin', '*')
    headers=headers.append('my-token','ABCCCBA')
    return headers
  }
}
