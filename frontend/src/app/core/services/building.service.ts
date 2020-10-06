import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { filter, switchMap, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Building } from '../models/building.model';

@Injectable({
  providedIn: 'root',
})
export class BuildingService {
  buildings$ = this.authenticationService.currentUser$.pipe(
    filter(user => user !== null),
    switchMap(_ => this.fetchBuildings()),
    map(this.countByType),
  );

  private buildingsUrl = `${environment.apiUrl}/buildings`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {}

  private fetchBuildings() {
    return this.http.get<Array<Building>>(this.buildingsUrl);
  }

  private countByType(buildings: Array<Building>) {
    let flowControllers = 0;
    let reefCastles = 0;
    for (const building of buildings) {
      if (building.name === 'áramlásirányító') flowControllers += 1;
      else if (building.name === 'zátonyvár') reefCastles += 1;
    }
    return { flowControllers, reefCastles };
  }
}
