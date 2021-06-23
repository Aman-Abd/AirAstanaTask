import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from './person';

const AUTH_API = 'https://localhost:44302/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  person: Person = new Person();
  constructor(private http: HttpClient) { }

  login(credentials): Observable<any> {
    this.person.Login = credentials.username;
    this.person.Password = credentials.password;
    return this.http.post(AUTH_API + 'token', this.person);
  }
}
