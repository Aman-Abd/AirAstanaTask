import { Component } from '@angular/core';
import { TokenStorageService } from '../person/token-storage.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor( private tokenStorage: TokenStorageService) { }

  isExpanded = false;
  LogIn = this.tokenStorage.getToken() != null && this.tokenStorage.getToken() != "";

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
