import { Injectable } from '@angular/core';
import { BuildingService } from './building.service';
import { CountryService } from './country.service';
import { UnitService } from './unit.service';
import { combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class StatService {
  stat$ = combineLatest(
    this.buildingService.buildings$,
    this.countyService.country$,
    this.unitService.units$,
  ).pipe(
    map(([buildings, country, units]) => {
      return { buildings, country, units };
    }),
  );

  constructor(
    private buildingService: BuildingService,
    private countyService: CountryService,
    private unitService: UnitService,
  ) {}
}
