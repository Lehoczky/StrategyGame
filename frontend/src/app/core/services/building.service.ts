import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { filter, switchMap, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Building } from '../models/building.model';
import { BehaviorSubject } from 'rxjs';

class Buildings {
  flowControllers: number;
  reefCastles: number;
}

const initialState: Buildings = {
  flowControllers: 0,
  reefCastles: 0,
};

@Injectable({
  providedIn: 'root',
})
export class BuildingService {
  private buildingsSubject$ = new BehaviorSubject<Buildings>(initialState);
  buildings$ = this.buildingsSubject$.asObservable();

  private buildingsUrl = `${environment.apiUrl}/buildings`;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthService,
  ) {
    this.authenticationService.currentUser$
      .pipe(
        filter(user => user !== null),
        switchMap(_ => this.fetchBuildings()),
        map(this.countByType),
      )
      .subscribe(buildings => {
        this.buildingsSubject$.next(buildings);
      });
  }

  purchaseBuilding(buildingType: string): void {
    this.http
      .post<Building>(this.buildingsUrl, { name: buildingType })
      .subscribe(() => {
        const currentState = this.buildingsSubject$.getValue();
        const newState = {
          ...currentState,
          buildingType: currentState[buildingType] + 1,
        };
        this.buildingsSubject$.next(newState);
      });
  }

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
