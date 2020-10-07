import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss']
})
export class BuildingsPageComponent implements OnInit {
  selectedIndex: number;

  readonly buildingsInStore: any[] = [
    {
      name: 'Zátonyvár', price: 1000, units: 200, population: 0, coralPerTurn: 0,
      img: '../../../../../../assets/img/undersea_game-07.png', owned: 0,
      description: '200 egységnek nyújt szállást'
    },
    {
      name: 'Áramlásirányító', price: 1000, units: 0, population: 50, coralPerTurn: 200,
      img: '../../../../../../assets/img/undersea_game-05.png', owned: 0,
      description: `50 embert ad a népességhez. 200 korallt termel körönként`
    }
  ];

  constructor() { }

  ngOnInit() {
  }

  selectBuilding(index: number) {
    this.selectedIndex = index;
  }
}

