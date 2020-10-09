import { Component, OnInit } from '@angular/core';
import { BuildingService } from 'src/app/features/buildings/building.service';
import { Building } from '../../building.model';
import { CountryService } from 'src/app/core/services/country.service';

@Component({
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss'],
})
export class BuildingsPageComponent implements OnInit {
  buildings$ = this.buildingService.buildings$;
  canBuy$ = this.countryService.canBuy$;
  selectedIndex: number;
  selectedBuilding: Building;

  constructor(
    public buildingService: BuildingService,
    public countryService: CountryService,
  ) {}

  ngOnInit() {
    const startingPrice = 0;
    this.countryService.calculateIfCanBuy(startingPrice);
  }

  selectBuilding(index: number, building: Building) {
    this.selectedIndex = index;
    this.selectedBuilding = building;
    this.countryService.calculateIfCanBuy(building.price);
  }

  purchaseBuilding() {
    if (this.selectedBuilding) {
      this.buildingService.purchaseBuilding(this.selectedBuilding);
    }
  }
}
