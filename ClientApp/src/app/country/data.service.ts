import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from './country';

@Injectable()
export class DataService {
  private url = "/api/Countries";

  constructor(private http: HttpClient) {
  }

  getCountrys() {
    return this.http.get(this.url);
  }

  getCountry(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createCountry(country: Country) {
    return this.http.post(this.url, country);
  }
  updateCountry(id: number, country: Country) {

    return this.http.put(this.url + '/' + id, country);
  }
  deleteCountry(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
