import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Flights } from '../flights/flights';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'app';
  flight: Flights = new Flights();
  flights: Flights[];
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.loadFlights();
  }

  loadFlights() {
    this.getFlights().subscribe((data: Flights[]) => this.flights = data);
  }

  getFlights() {
    return this.http.get("/api/Flights");
  }

}
