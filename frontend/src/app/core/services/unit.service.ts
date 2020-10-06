import { Injectable } from '@angular/core';
import { filter, switchMap, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Unit } from '../models/unit.model';

@Injectable({
  providedIn: 'root',
})
export class UnitService {
  units$ = this.authenticationService.currentUser$.pipe(
    filter(user => user !== null),
    switchMap(_ => this.fetchUnits()),
    map(this.countByType),
  );

  private unitsUrl = `${environment.apiUrl}/units`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {}

  private fetchUnits() {
    return this.http.get<Array<Unit>>(this.unitsUrl);
  }

  private countByType(units: Array<Unit>) {
    let attackSeals = 0;
    let battleSeaHorses = 0;
    let laserSharks = 0;
    for (const unit of units) {
      if (unit.name === 'rohamfóka') attackSeals += 1;
      else if (unit.name === 'csatacsikó') battleSeaHorses += 1;
      else if (unit.name === 'lézercápa') laserSharks += 1;
    }
    return { attackSeals, battleSeaHorses, laserSharks };
  }
}
