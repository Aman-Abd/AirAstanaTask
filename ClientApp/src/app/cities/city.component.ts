import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { City } from './City'
import { Country } from '../country/country';

@Component({
  selector: 'city',
  templateUrl: './city.component.html',
  providers: [DataService]
})

export class CityComponent implements OnInit {
  city: City = new City();
  cities: City[];
  countries: Country[];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadCities();    // загрузка данных при старте компонента
    this.loadCountries();
  }

  loadCities() {
    this.dataService.getCities()
      .subscribe((data: City[]) => this.cities = data);
  }

  loadCountries() {
    this.dataService.getCountries().subscribe((data: Country[]) => this.countries = data);
  }

  save() {
    if (this.city.id == null) {
      this.dataService.createCity(this.city)
        .subscribe((data: City) => this.cities.push(data));
    } else {
      this.dataService.updateCity(this.city.id, this.city)
        .subscribe(data => this.loadCities());
    }
    this.cancel();
  }
  editCity(c: City) {
    this.city = c;
  }
  cancel() {
    this.city = new City();
    this.tableMode = true;
  }
  delete(p: City) {
    this.dataService.deleteCity(p.id)
      .subscribe(data => this.loadCities());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}

