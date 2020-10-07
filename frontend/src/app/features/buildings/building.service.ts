import { Injectable } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { filter, switchMap, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Building } from './building.model';
import { BehaviorSubject } from 'rxjs';

class BuildingsByCount {
  flowController: number;
  reefCastle: number;
}

const initialState: BuildingsByCount = {
  flowController: 0,
  reefCastle: 0,
};

@Injectable({
  providedIn: 'root',
})
export class BuildingService {
  private buildingsSubject$ = new BehaviorSubject<BuildingsByCount>(
    initialState,
  );
  buildings$ = this.buildingsSubject$.asObservable();
  buildingsWithDescription$ = this.buildings$.pipe(
    map(buildings => {
      return [
        {
          name: 'Áramlásirányító',
          typeName: 'flowController',
          price: 1000,
          units: 0,
          population: 50,
          coralPerTurn: 200,
          owned: buildings.flowController,
          img: '../../../../../../assets/img/undersea_game-05.png',
          description: `50 embert ad a népességhez. 200 korallt termel körönként`,
        },
        {
          name: 'Zátonyvár',
          typeName: 'reefCastle',
          price: 1000,
          units: 200,
          population: 0,
          coralPerTurn: 0,
          owned: buildings.reefCastle,
          img: '../../../../../../assets/img/undersea_game-07.png',
          description: '200 egységnek nyújt szállást',
        },
      ] as Array<Building>;
    }),
  );

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
          [buildingType]: currentState[buildingType] + 1,
        };
        this.buildingsSubject$.next(newState);
      });
  }

  private fetchBuildings() {
    return this.http.get<Array<Building>>(this.buildingsUrl);
  }

  private countByType(buildings: Array<Building>) {
    let flowController = 0;
    let reefCastle = 0;
    for (const building of buildings) {
      if (building.name === 'áramlásirányító') flowController += 1;
      else if (building.name === 'zátonyvár') reefCastle += 1;
    }
    return { flowController, reefCastle };
  }
}
