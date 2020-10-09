import { Injectable } from '@angular/core';
import { filter, switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { Unit } from './unit.model';
import { BehaviorSubject, combineLatest } from 'rxjs';
import { CountryService } from 'src/app/core/services/country.service';

class UnitByCount {
  count: number;
  unitId: number;
}

@Injectable({
  providedIn: 'root',
})
export class UnitService {
  private unitsUrl = `${environment.apiUrl}/units`;
  private types$ = new BehaviorSubject<Array<Unit>>([]);
  private unitsSubject$ = new BehaviorSubject<Array<UnitByCount>>([]);

  unitTypes$ = this.types$.asObservable();
  unitCounts$ = this.unitsSubject$.asObservable();
  units$ = combineLatest(this.unitTypes$, this.unitCounts$).pipe(
    map(([unitTypes, unitCounts]) => {
      return unitTypes.map(unit => {
        const unitCount = unitCounts.find(x => x.unitId == unit.id);
        const owned = unitCount !== undefined ? unitCount.count : 0;
        return { ...unit, owned } as Unit;
      });
    }),
  );

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
    public countryService: CountryService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchUnits()),
      )
      .subscribe(units => {
        this.unitsSubject$.next(units);
      });

    this.fetchTypes().subscribe(units => {
      this.types$.next(units);
    });
  }

  purchaseUnits(units: object, totalCost: number): void {
    this.countryService.pay(totalCost);
    for (const [name, count] of Object.entries(units)) {
      const id = this.types$.getValue().find(u => u.name === name).id;
      this.http.post(this.unitsUrl, { name, count }).subscribe(() => {
        const state = this.unitsSubject$.getValue();
        for (let i = 0; i < state.length; i++) {
          const element = state[i];

          if (element.unitId === id) {
            state.slice(i, 1);
            element.count += count;
            this.unitsSubject$.next([...state, element]);
            return;
          }
        }
        this.unitsSubject$.next([...state, { unitId: id, count: count }]);
      });
    }
  }

  private fetchTypes() {
    return this.http.get<Array<Unit>>(this.unitsUrl + '/types');
  }

  private fetchUnits() {
    return this.http.get<Array<UnitByCount>>(this.unitsUrl);
  }
}
