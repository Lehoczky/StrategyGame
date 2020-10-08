import { Injectable } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { filter, switchMap, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Building } from './building.model';
import { BehaviorSubject, combineLatest } from 'rxjs';

class BuildingByCount {
  count: number;
  buildingId: number;
}

@Injectable({
  providedIn: 'root',
})
export class BuildingService {
  private buildingsUrl = `${environment.apiUrl}/buildings`;
  private types$ = new BehaviorSubject<Array<Building>>([]);
  private buildingsSubject$ = new BehaviorSubject<Array<BuildingByCount>>([]);

  buildingTypes$ = this.types$.asObservable();
  buildingsCount$ = this.buildingsSubject$.asObservable();
  buildings$ = combineLatest(this.buildingTypes$, this.buildingsCount$).pipe(
    map(([buildingTypes, buildingCounts]) => {
      return buildingTypes.map(building => {
        const buildingCount = buildingCounts.find(
          x => x.buildingId === building.id,
        );
        const owned = buildingCount !== undefined ? buildingCount.count : 0;
        return { ...building, owned } as Building;
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
        switchMap(_ => this.fetchBuildings()),
      )
      .subscribe(buildings => {
        this.buildingsSubject$.next(buildings);
      });

    this.fetchTypes().subscribe(buildings => {
      this.types$.next(buildings);
    });
  }

  purchaseBuilding(building: Building): void {
    this.http
      .post<Building>(this.buildingsUrl, { name: building.name })
      .subscribe(() => {
        const state = this.buildingsSubject$.getValue();
        for (let i = 0; i < state.length; i++) {
          const element = state[i];
          if (element.buildingId === building.id) {
            state.slice(i, 1);
            element.count += 1;
            this.buildingsSubject$.next([...state, element]);
            return;
          }
        }
        this.buildingsSubject$.next([
          ...state,
          { buildingId: building.id, count: 1 },
        ]);
      });
  }

  private fetchTypes() {
    return this.http.get<Array<Building>>(this.buildingsUrl + '/types');
  }

  private fetchBuildings() {
    return this.http.get<Array<BuildingByCount>>(this.buildingsUrl);
  }
}
