import { Injectable } from '@angular/core';
import { filter, switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { Unit } from './unit.model';
import { BehaviorSubject, combineLatest } from 'rxjs';

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
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchUnits()),
      )
      .subscribe(units => {
        this.unitsSubject$.next(units);
      });

    this.fetchTypes()
      .pipe(
        map(units => {
          return units.map(unit => {
            const image = this.imageNamesForUnit(unit);
            return { ...unit, image } as Unit;
          });
        }),
      )
      .subscribe(units => {
        this.types$.next(units);
      });
  }

  purchaseUnits(units: object) {
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

  private imageNamesForUnit(unit: Unit): string {
    if (unit.name === 'lézercápa') return 'svg/007-shark.svg';
    else if (unit.name === 'rohamfóka') return 'svg/025-seal.svg';
    else if (unit.name === 'csatacsikó') return 'svg/013-seahorse.svg';
  }
}
