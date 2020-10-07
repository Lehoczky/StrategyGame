import { Component } from '@angular/core';
import { UpgradeService } from 'src/app/features/upgrades/upgrade.service';

@Component({
  templateUrl: './upgrades.page.component.html',
  styleUrls: ['./upgrades.page.component.scss'],
})
export class UpgradesPageComponent {
  upgrades$ = this.upgradeService.upgradesWithDescription$;
  selectedIndex: number;
  selectedUpgrade;

  constructor(public upgradeService: UpgradeService) {}

  selectUpgrade(index: number, upgrade) {
    this.selectedIndex = index;
    this.selectedUpgrade = upgrade;
  }

  purchaseUpgrade() {
    this.upgradeService.purchaseUpgrade(this.selectedUpgrade.typeName);
  }
}
