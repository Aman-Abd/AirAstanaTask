import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Flights } from './flights';
import { City } from '../cities/City';

@Component({
  selector: 'flight',
  templateUrl: './flights.component.html',
  providers: [DataService]
})

export class FlightComponent implements OnInit {
  flight: Flights = new Flights();
  flights: Flights[];
  cities: City[];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadFlights();    // загрузка данных при старте компонента
    this.loadCities();
  }

  loadFlights() {
    this.dataService.getFlights()
      .subscribe((data: Flights[]) => this.flights = data);
  }

  loadCities() {
    this.dataService.getCities().subscribe((data: City[]) => this.cities = data);
  }

  save() {
    if (this.flight.id == null) {
      this.dataService.createFlight(this.flight)
        .subscribe((data: Flights) => this.flights.push(data));
    } else {
      this.dataService.updateFlight(this.flight.id, this.flight)
        .subscribe(data => this.loadCities());
    }
    this.cancel();
  }
  editFlight(f: Flights) {
    this.flight = f;
  }
  cancel() {
    this.flight = new Flights();
    this.tableMode = true;
  }
  delete(f: Flights) {
    this.dataService.deleteFlight(f.id)
      .subscribe(data => this.loadCities());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
