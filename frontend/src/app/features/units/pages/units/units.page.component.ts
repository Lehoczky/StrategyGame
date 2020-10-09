import { Component, OnInit } from '@angular/core';
import { UnitService } from 'src/app/features/units/unit.service';
import { CountryService } from 'src/app/core/services/country.service';

@Component({
  templateUrl: './units.page.component.html',
  styleUrls: ['./units.page.component.scss'],
})
export class UnitsPageComponent implements OnInit {
  units$ = this.unitService.units$;
  canBuy$ = this.countryService.canBuy$;
  toBuy = {};
  totalCost = 0;

  constructor(
    public unitService: UnitService,
    public countryService: CountryService,
  ) {}

  ngOnInit() {
    this.countryService.calculateIfCanBuy(this.totalCost);
  }

  manageAmount(unitName: string, price: number, amount: number) {
    if (this.toBuy.hasOwnProperty(unitName)) this.toBuy[unitName] += amount;
    else this.toBuy[unitName] = amount;
    this.totalCost += price * amount;
    this.countryService.calculateIfCanBuy(this.totalCost);
  }

  purchaseUnits() {
    this.unitService.purchaseUnits(this.toBuy);
    this.toBuy = {};
  }
}
