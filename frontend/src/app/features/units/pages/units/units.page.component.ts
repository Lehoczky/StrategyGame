import { Component } from '@angular/core';
import { UnitService } from 'src/app/features/units/unit.service';

@Component({
  templateUrl: './units.page.component.html',
  styleUrls: ['./units.page.component.scss'],
})
export class UnitsPageComponent {
  units$ = this.unitService.units$;
  toBuy = {};

  constructor(public unitService: UnitService) {}

  manageAmount(unitName: string, amount: number) {
    if (amount < 0) {
      amount = 0;
    }

    if (this.toBuy.hasOwnProperty(unitName)) this.toBuy[unitName] += amount;
    else this.toBuy[unitName] = amount;
  }

  purchaseUnits() {
    this.unitService.purchaseUnits(this.toBuy);
    this.toBuy = {};
  }
}
