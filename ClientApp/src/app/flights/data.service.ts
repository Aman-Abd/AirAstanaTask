import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Flights } from './flights';

@Injectable()
export class DataService {
  private url = "/api/Flights";

  constructor(private http: HttpClient) {
  }

  getCities() {
    return this.http.get('/api/Cities');
  }

  getFlights() {
    return this.http.get(this.url);
  }

  getFlight(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createFlight(flight: Flights) {
    return this.http.post(this.url, flight);
  }
  updateFlight(id: number, flight: Flights) {

    return this.http.put(this.url + '/' + id, flight);
  }
  deleteFlight(id: number) {
    return this.http.delete(this.url + '/' + id);
  }

}
