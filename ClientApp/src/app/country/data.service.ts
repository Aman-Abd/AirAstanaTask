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

  createCountry(product: Country) {
    return this.http.post(this.url, product);
  }
  updateCountry(product: Country) {

    return this.http.put(this.url, product);
  }
  deleteCountry(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
