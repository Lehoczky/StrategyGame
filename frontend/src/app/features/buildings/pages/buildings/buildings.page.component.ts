import { Component } from '@angular/core';
import { BuildingService } from 'src/app/features/buildings/building.service';
import { Building } from '../../building.model';

@Component({
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss'],
})
export class BuildingsPageComponent {
  selectedIndex: number;
  selectedBuilding: Building;
  buildings$ = this.buildingService.buildings$;

  constructor(public buildingService: BuildingService) {}

  selectBuilding(index: number, building) {
    this.selectedIndex = index;
    this.selectedBuilding = building;
  }

  purchaseBuilding() {
    this.buildingService.purchaseBuilding(this.selectedBuilding);
  }
}
