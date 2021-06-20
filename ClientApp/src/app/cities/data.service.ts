import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { City } from './City'

@Injectable()
export class DataService {
  private url = "/api/Cities";

  constructor(private http: HttpClient) {
  }

  getCountries() {
    return this.http.get('/api/Countries');
  }

  getCities() {
    return this.http.get(this.url);
  }

  getCity(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createCity(city: City) {
    return this.http.post(this.url, city);
  }
  updateCity(id: number, city: City) {

    return this.http.put(this.url + '/' + id, city);
  }
  deleteCity(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

}
