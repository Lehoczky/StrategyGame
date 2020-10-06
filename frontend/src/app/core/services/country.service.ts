import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country.model';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { switchMap, filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  country$ = this.authenticationService.currentUser$.pipe(
    filter(user => user !== null),
    switchMap(_ => this.fetchCountry()),
  );

  private countryUrl = `${environment.apiUrl}/country`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {}

  private fetchCountry() {
    return this.http.get<Country>(this.countryUrl);
  }
}
