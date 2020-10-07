import { Injectable } from '@angular/core';
import { filter, switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Unit } from '../models/unit.model';
import { BehaviorSubject } from 'rxjs';

class UnitsByCount {
  attackSeal: number;
  battleSeaHorse: number;
  laserShark: number;
}

const initialState: UnitsByCount = {
  attackSeal: 0,
  battleSeaHorse: 0,
  laserShark: 0,
};

@Injectable({
  providedIn: 'root',
})
export class UnitService {
  private unitsSubject$ = new BehaviorSubject<UnitsByCount>(initialState);
  units$ = this.unitsSubject$.asObservable();
  unitsWithDescription$ = this.units$.pipe(
    map(units => {
      return [
        {
          name: 'Lézercápa',
          typeName: 'laserShark',
          price: 100,
          attack: 5,
          defense: 5,
          costPerTurn: 3,
          coralPerTurn: 2,
          img: '../../../../../assets/svg/007-shark.svg',
          owned: units.laserShark,
        },
        {
          name: 'Rohamfóka',
          typeName: 'attackSeal',
          price: 50,
          attack: 6,
          defense: 2,
          costPerTurn: 1,
          coralPerTurn: 1,
          img: '../../../../../assets/svg/025-seal.svg',
          owned: units.attackSeal,
        },
        {
          name: 'Csatacsikó',
          typeName: 'battleSeaHorse',
          price: 50,
          attack: 2,
          defense: 6,
          costPerTurn: 1,
          coralPerTurn: 1,
          img: '../../../../../assets/svg/013-seahorse.svg',
          owned: units.battleSeaHorse,
        },
      ] as Array<Unit>;
    }),
  );

  private unitsUrl = `${environment.apiUrl}/units`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchUnits()),
        map(this.countByType),
      )
      .subscribe(units => {
        this.unitsSubject$.next(units);
      });
  }

  purchaseUnits(units) {
    for (const [name, count] of Object.entries(units)) {
      this.http.post(this.unitsUrl, { name, count }).subscribe(() => {
        const currentState = this.unitsSubject$.getValue();
        const newState = {
          ...currentState,
          [name]: currentState[name] += count,
        };
        this.unitsSubject$.next(newState);
      });
    }
  }

  private fetchUnits() {
    return this.http.get<Array<Unit>>(this.unitsUrl);
  }

  private countByType(units: Array<Unit>) {
    let attackSeal = 0;
    let battleSeaHorse = 0;
    let laserShark = 0;
    for (const unit of units) {
      if (unit.name === 'rohamfóka') attackSeal += 1;
      else if (unit.name === 'csatacsikó') battleSeaHorse += 1;
      else if (unit.name === 'lézercápa') laserShark += 1;
    }
    return { attackSeal, battleSeaHorse, laserShark };
  }
}
