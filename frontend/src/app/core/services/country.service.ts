import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country.model';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { switchMap, filter } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  private countryUrl = `${environment.apiUrl}/country`;
  private countrySubject$ = new BehaviorSubject<Country>(null);
  private canBuySubject$ = new BehaviorSubject<boolean>(true);

  country$ = this.countrySubject$.pipe(filter(c => c !== null));
  canBuy$ = this.canBuySubject$.asObservable();

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchCountry()),
      )
      .subscribe(country => {
        this.countrySubject$.next(country);
      });
  }

  calculateIfCanBuy(cost: number): void {
    const pearls = this.countrySubject$.getValue().pearls;
    const canBuy = pearls >= cost;
    this.canBuySubject$.next(canBuy);
  }

  private fetchCountry() {
    return this.http.get<Country>(this.countryUrl);
  }
}
