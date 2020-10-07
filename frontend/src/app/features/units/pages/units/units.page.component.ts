import { Component } from '@angular/core';
import { UnitService } from 'src/app/core/services/unit.service';

@Component({
  templateUrl: './units.page.component.html',
  styleUrls: ['./units.page.component.scss'],
})
export class UnitsPageComponent {
  units$ = this.unitService.unitsWithDescription$;
  toBuy = {
    laserShark: 0,
    attackSeal: 0,
    battleSeaHorse: 0,
  };

  constructor(public unitService: UnitService) {}

  manageAmount(unitName: string, amount: number) {
    this.toBuy[unitName] += amount;
  }

  purchaseUnits() {
    this.unitService.purchaseUnits(this.toBuy);
    this.toBuy = {
      laserShark: 0,
      attackSeal: 0,
      battleSeaHorse: 0,
    };
  }
}
