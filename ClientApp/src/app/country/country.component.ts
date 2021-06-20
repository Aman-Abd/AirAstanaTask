import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Country } from './country';

@Component({
  selector: 'app',
  templateUrl: './country.component.html',
  providers: [DataService]
})

export class CountryComponent implements OnInit {
  country: Country = new Country();
  countries: Country[];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadCountries();    // загрузка данных при старте компонента  
  }

  loadCountries() {
    this.dataService.getCountrys()
      .subscribe((data: Country[]) => this.countries = data);
  }

  save() {
    if (this.country.id == null) {
      this.dataService.createCountry(this.country)
        .subscribe((data: Country) => this.countries.push(data));
    } else {
      this.dataService.updateCountry(this.country.id, this.country)
        .subscribe(data => this.loadCountries());
    }
    this.cancel();
  }
  editCountry(p: Country) {
    this.country = p;
  }
  cancel() {
    this.country = new Country();
    this.tableMode = true;
  }
  delete(p: Country) {
    this.dataService.deleteCountry(p.id)
      .subscribe(data => this.loadCountries());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}
