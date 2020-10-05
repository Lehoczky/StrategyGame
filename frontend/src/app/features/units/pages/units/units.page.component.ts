import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './units.page.component.html',
  styleUrls: ['./units.page.component.scss']
})
export class UnitsPageComponent implements OnInit {
  readonly unitsInStore: any[] = [
    {
      name: 'Lézercápa', price: 100, attack: 5, defense: 5, costPerTurn: 3, coralPerTurn: 2,
      img: '../../../../../assets/svg/007-shark.svg', amountToBuy: 0, owned: 0
    },
    {
      name: 'Rohamfóka', price: 50, attack: 6, defense: 2, costPerTurn: 1, coralPerTurn: 1,
      img: '../../../../../assets/svg/025-seal.svg', amountToBuy: 0, owned: 0
    },
    {
      name: 'Csatacsikó', price: 50, attack: 2, defense: 6, costPerTurn: 1, coralPerTurn: 1,
      img: '../../../../../assets/svg/013-seahorse.svg', amountToBuy: 0, owned: 0
    }
  ];

  constructor() { }

  ngOnInit() { }

  manageAmount(unitName: string, amount: number) {
    const unit = this.unitsInStore.find(u => u.name === unitName);
    unit.amountToBuy += amount;
    if (unit.amountToBuy < 0) {
      unit.amountToBuy = 0;
    }
  }

}
