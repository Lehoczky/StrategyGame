import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './upgrades.page.component.html',
  styleUrls: ['./upgrades.page.component.scss']
})
export class UpgradesPageComponent implements OnInit {
  selectedIndex: number;

  readonly upgradesInStore: any[] = [
    {
      name: 'Iszaptraktor',
      coralBonus: 10,
      defenseBonus: 0,
      attackBonus: 0,
      taxBonus: 0,
      img: '../../../../../assets/img/undersea_game-09.png',
      description: 'növeli a korall termesztését 10%-kal',
      owned: false
    },
    {
      name: 'Iszapkombájn',
      coralBonus: 15,
      defenseBonus: 0,
      attackBonus: 0,
      taxBonus: 0,
      img: '../../../../../assets/img/undersea_game-10.png',
      description: 'növeli a korall termesztését 15%-kal',
      owned: false
    }, {
      name: 'Korallfal',
      coralBonus: 0,
      defenseBonus: 20,
      attackBonus: 0,
      taxBonus: 0,
      img: '../../../../../assets/img/undersea_game-03.png',
      description: 'növeli a védelmi pontokat 20%-kal',
      owned: false
    }, {
      name: 'Szonárágyú',
      coralBonus: 10,
      defenseBonus: 0,
      attackBonus: 20,
      taxBonus: 0,
      img: '../../../../../assets/img/undersea_game-03.png',
      description: 'növeli a támadópontokat 20%-kal',
      owned: false
    }, {
      name: 'Vízalatti harcművészetek',
      coralBonus: 0,
      defenseBonus: 10,
      attackBonus: 10,
      taxBonus: 0,
      img: '../../../../../assets/img/undersea_game-03.png',
      description: 'növeli a védelmi és támadóerőt 10%-kal',
      owned: false
    },
    {
      name: 'Alkímia',
      coralBonus: 0,
      defenseBonus: 0,
      attackBonus: 0,
      taxBonus: 30,
      img: '../../../../../assets/img/undersea_game-03.png',
      description: 'növeli a beszedett adót 30%-kal',
      owned: false
    },
  ];

  constructor() { }

  ngOnInit() {
  }

  selectUpgrade(index: number) {
    this.selectedIndex = index;
  }

}
